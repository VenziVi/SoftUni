namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            DepartmentsImportDto[] departments = JsonConvert.DeserializeObject<DepartmentsImportDto[]>(jsonString);

            foreach (var department in departments)
            {

                if (!IsValid(department)
                    || department.Cells.Count() == 0 
                    || !department.Cells.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Department dep = new Department()
                {
                    Name = department.Name,
                };

                var cells = new HashSet<Cell>();

                foreach (var cell in department.Cells)
                {
                    Cell currCell = new Cell()
                    {
                        CellNumber = cell.CellNumber,
                        HasWindow = bool.Parse(cell.HasWindow)
                    };

                    cells.Add(currCell);
                }

                dep.Cells = cells;
                sb.AppendLine($"Imported {dep.Name} with {dep.Cells.Count} cells");
                context.Departments.Add(dep);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd(); 
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            PrisonersImportDto[] prisoners = JsonConvert.DeserializeObject<PrisonersImportDto[]>(jsonString);

            var prisonersList = new HashSet<Prisoner>();

            foreach (var prisoner in prisoners)
            {
                bool isDateValid = DateTime.TryParseExact(prisoner.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime incarceDate);

                DateTime? releaseDate = null;
                bool IsreleaseDateValid = true;

                if (prisoner.ReleaseDate != null)
                {
                    IsreleaseDateValid = DateTime.TryParseExact(prisoner.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime currDate);

                    if (IsreleaseDateValid)
                    {
                        releaseDate = currDate;
                    }
                }

                if (!IsValid(prisoner) || !prisoner.Mails.All(IsValid) || !isDateValid || !IsreleaseDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Prisoner p = new Prisoner()
                {
                    FullName = prisoner.FullName,
                    Nickname = prisoner.Nickname,
                    Age = prisoner.Age,
                    IncarcerationDate = incarceDate,
                    ReleaseDate = releaseDate,
                    Bail = prisoner.Bail,
                    CellId = prisoner.CellId,
                };

                var mails = new HashSet<Mail>();

                foreach (var mail in prisoner.Mails)
                {
                    Mail currMail = new Mail()
                    {
                        Description = mail.Description,
                        Sender = mail.Sender,
                        Address = mail.Address
                    };
                    mails.Add(currMail);
                }

                p.Mails = mails;
                prisonersList.Add(p);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(prisonersList);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var sb = new StringBuilder();
            using StringReader reader = new StringReader(xmlString);

            XmlSerializer serializer = new XmlSerializer(typeof(OfficerImportDto[]), new XmlRootAttribute("Officers"));

            OfficerImportDto[] officers = (OfficerImportDto[])serializer.Deserialize(reader);

            var officerList = new HashSet<Officer>();

            foreach (var officer in officers)
            {
                string[] positions = new string[] { "Overseer", "Guard", "Watcher", "Labour"};
                string[] weapons = new string[] { "Knife", "FlashPulse", "ChainRifle", "Pistol", "Sniper" };

                if (!IsValid(officer) 
                    || !positions.Contains(officer.Position) 
                    || !weapons.Contains(officer.Weapon))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Officer currOfficer = new Officer()
                {
                    FullName = officer.Name,
                    Salary = officer.Money,
                    Position = (Position)Enum.Parse(typeof(Position), officer.Position),
                    Weapon = (Weapon)Enum.Parse(typeof(Weapon), officer.Weapon),
                    DepartmentId = officer.DepartmentId,
                };

                var prisonersList = new HashSet<OfficerPrisoner>();

                foreach (var prisoner in officer.Prisoners)
                {
                    OfficerPrisoner op = new OfficerPrisoner()
                    {
                        OfficerId = currOfficer.Id,
                        PrisonerId = prisoner.id
                    };

                    prisonersList.Add(op);
                }

                currOfficer.OfficerPrisoners = prisonersList;
                sb.AppendLine($"Imported {officer.Name} ({officer.Prisoners.Count()} prisoners)");
                officerList.Add(currOfficer);
            }

            context.Officers.AddRange(officerList);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}