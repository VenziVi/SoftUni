namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context
                .Prisoners
                .Where(p => ids.Contains(p.Id))
                .ToArray()
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers.Select(o => new
                    {
                        OfficerName = o.Officer.FullName,
                        Department = o.Officer.Department.Name,
                    })
                    .OrderBy(o => o.OfficerName),
                    TotalOfficerSalary = decimal.Parse(p.PrisonerOfficers.Select(po => po.Officer).Sum(po => po.Salary).ToString("f2"))
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            var result = JsonConvert.SerializeObject(prisoners, Formatting.Indented);
            return result.ToString();
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var sb = new StringBuilder();

            using StringWriter writer = new StringWriter(sb);

            XmlSerializer serializer = new XmlSerializer(typeof(PrisonerInboxExportDto[]), new XmlRootAttribute("Prisoners"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            string[] prisonersArr = prisonersNames.Split(',', StringSplitOptions.RemoveEmptyEntries);

            var prisoners = context
                .Prisoners
                .Where(p => prisonersArr.Contains(p.FullName))
                .Select(p => new PrisonerInboxExportDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = p.Mails.Select(m => new MessagesExportDto
                    {
                        Description = m.Description,
                    })
                    .ToArray()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            foreach (var prisoner in prisoners)
            {
                foreach (var pm in prisoner.EncryptedMessages)
                {
                    pm.Description = Reverse(pm.Description);
                }
            }

            serializer.Serialize(writer, prisoners, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}