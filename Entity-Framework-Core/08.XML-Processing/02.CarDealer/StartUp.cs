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

	//02.Import parts

	public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PartsImport[]), new XmlRootAttribute("Parts"));

            using StringReader reader = new StringReader(inputXml);

            PartsImport[] dtos = (PartsImport[])serializer.Deserialize(reader);

            var parts = new HashSet<Part>();

            foreach (var dto in dtos)
            {
                var supplier = context.Suppliers.FirstOrDefault(s => s.Id == dto.supplierId);

                if (supplier == null)
                    continue;

                Part p = new Part
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    Quantity = dto.Quantity,
                    SupplierId = dto.supplierId
                };

                parts.Add(p);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

	//03.Import cars

	public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CarsImport[]), new XmlRootAttribute("Cars"));

            using StringReader reader = new StringReader(inputXml);

            CarsImport[] dtos = (CarsImport[])serializer.Deserialize(reader);

            ICollection<Car> cars = new HashSet<Car>();

            foreach (var dto in dtos)
            {
                Car c = new Car
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TravelledDistance = dto.TraveledDistance
                };

                ICollection<PartCar> partCar = new HashSet<PartCar>();

                foreach (var partId in dto.Parts.Select(p => p.Id).Distinct())
                {
                    Part part = context.Parts.Find(partId);

                    if (part == null)
                        continue;

                    PartCar pc = new PartCar
                    {
                        Car = c,
                        Part = part
                    };

                    partCar.Add(pc);
                }

                c.PartCars = partCar;
                cars.Add(c);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

	//04.Import customers

	public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CustomerImport[]), new XmlRootAttribute("Customers"));

            using StringReader reader = new StringReader(inputXml);

            CustomerImport[] dtos = (CustomerImport[])serializer.Deserialize(reader);

            var customers = new HashSet<Customer>();

            foreach (var dto in dtos)
            {
                Customer c = new Customer
                {
                    Name = dto.Name,
                    BirthDate = DateTime.Parse(dto.BirthDate),
                    IsYoungDriver = bool.Parse(dto.IsYoungDriver)
                };

                customers.Add(c);
            }

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }
    }
}