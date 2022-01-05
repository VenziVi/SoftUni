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
            
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            
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