using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    //[XmlType("Users")]
    public class SellersExportDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public UsersWithProductsExportDto[] Users { get; set; }
    }
}
