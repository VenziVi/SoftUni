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

	//05.Import sales

	public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SalesImport[]), new XmlRootAttribute("Sales"));

            using StringReader reader = new StringReader(inputXml);

            SalesImport[] dtos = (SalesImport[])serializer.Deserialize(reader);

            var sales = new HashSet<Sale>();

            foreach (var dto in dtos)
            {
                var currCar = context
                    .Cars
                    .FirstOrDefault(c => c.Id == dto.CarId);

                if (currCar == null)
                    continue;

                Sale s = new Sale
                {
                    CarId = dto.CarId,
                    CustomerId = dto.CustomerId,
                    Discount = dto.Discount
                };

                sales.Add(s);
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

	//06.Export cars with distance

	public static string GetCarsWithDistance(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(CarWithDistanceExport[]), new XmlRootAttribute("cars"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);

            CarWithDistanceExport[] cars = context
                .Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .Select(c => new CarWithDistanceExport
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray();

            serializer.Serialize(writer, cars, namespaces);

            return sb.ToString().TrimEnd();
        }
	
	//07.Export cars with make BMW

	public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(BMWExport[]), new XmlRootAttribute("cars"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);

            BMWExport[] bmws = context
                .Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new BMWExport
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                }).ToArray();


            serializer.Serialize(writer, bmws, namespaces);

            return sb.ToString().TrimEnd();
        }

	\\08.Export local suppliers

	public static string GetLocalSuppliers(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(SupplierExport[]), new XmlRootAttribute("suppliers"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);

            SupplierExport[] suppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new SupplierExport
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToArray();

            serializer.Serialize(writer, suppliers, namespaces);

            return sb.ToString().TrimEnd();
        }

	//09.Export cars with list of parts

	public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(CarPartsExport[]), new XmlRootAttribute("cars"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);

            CarPartsExport[] carParts = context
                .Cars
                .Select(s => new CarPartsExport
                {
                    Make = s.Make,
                    Model = s.Model,
                    TravelledDistance = s.TravelledDistance,
                    Parts = s.PartCars.Select(p => new PartsExport
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            serializer.Serialize(writer, carParts, namespaces);

            return sb.ToString().TrimEnd();
        }

	//10.Export total sales by customer

	public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(CustomersExport[]), new XmlRootAttribute("customers"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);

            CustomersExport[] customers = context
                .Customers
                .Where(c => c.Sales.Any())
                .Select(c => new CustomersExport
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpendMoney = c.Sales
                    .SelectMany(s => s.Car.PartCars)
                    .Sum(p => p.Part.Price)
                })
                .OrderByDescending(c => c.SpendMoney)
                .ToArray();

            serializer.Serialize(writer, customers, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}