using CarDealer.Data;
using CarDealer.DTO.Export;
using CarDealer.DTO.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var input = File.ReadAllText("Datasets/sales.xml");

            //System.Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

       //01.import suppliers

	public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SuppliersImport[]), new XmlRootAttribute("Suppliers"));

            using StringReader reader = new StringReader(inputXml);

            SuppliersImport[] dtos = (SuppliersImport[])serializer.Deserialize(reader);

            var result = new HashSet<Supplier>();

            foreach (var dto in dtos)
            {
                Supplier s = new Supplier
                {
                    Name = dto.Name,
                    IsImporter = bool.Parse(dto.IsImporter)
                };

                result.Add(s);
            }

            context.Suppliers.AddRange(result);
            context.SaveChanges();

            return $"Successfully imported {result.Count}";
        }
    }
}