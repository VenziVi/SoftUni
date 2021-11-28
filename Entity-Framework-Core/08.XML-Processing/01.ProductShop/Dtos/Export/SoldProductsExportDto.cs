using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    public class SoldProductsExportDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public SellerProductsExportDto[] Products { get; set; }
    }
}
