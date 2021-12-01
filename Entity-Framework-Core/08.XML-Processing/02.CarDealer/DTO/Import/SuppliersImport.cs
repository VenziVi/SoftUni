using System.Xml.Serialization;

namespace CarDealer.DTO.Import
{
    [XmlType("Supplier")]
    public class SuppliersImport
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("isImporter")]
        public string IsImporter { get; set; }
    }
}
