using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Prisoner")]
    public class OfficerPrisonersImportDto
    {
        [XmlAttribute("id")]
        public int id { get; set; }
    }
}
