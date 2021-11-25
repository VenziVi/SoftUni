using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO.InputDTO;
using CarDealer.DTO.OutputDTO;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper mapper;
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var suppliersInput = File.ReadAllText("../../../Datasets/suppliers.json");
            //var partsInput = File.ReadAllText("../../../Datasets/parts.json");
            //var carsInput = File.ReadAllText("../../../Datasets/cars.json");
            //var customersInput = File.ReadAllText("../../../Datasets/customers.json");
            //var salesInput = File.ReadAllText("../../../Datasets/sales.json");

            //Console.WriteLine(ImportSuppliers(context, suppliersInput));
            //Console.WriteLine(ImportParts(context, partsInput));
            //Console.WriteLine(ImportCars(context, carsInput));
            //Console.WriteLine(ImportCustomers(context, customersInput));
            //Console.WriteLine(ImportSales(context, salesInput));

            Console.WriteLine(GetSalesWithAppliedDiscount(context));

        }

	//01.Import Suppliers

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IEnumerable<SupplaiersDto> suppliers = JsonConvert.DeserializeObject<IEnumerable<SupplaiersDto>>(inputJson);

            MapperConfiguration mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = new Mapper(mapperConfig);

            var mappedSupliers = mapper.Map<IEnumerable<Supplier>>(suppliers);

            context.Suppliers.AddRange(mappedSupliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

        //02.Import parts

	public static string ImportParts(CarDealerContext context, string inputJson) 
        {
            IEnumerable<PartsDto> parts = JsonConvert.DeserializeObject<IEnumerable<PartsDto>>(inputJson)
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId));

            MapperConfiguration mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = new Mapper(mapperConfig);

            var mappedParts = mapper.Map<IEnumerable<Part>>(parts);

            context.Parts.AddRange(mappedParts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

	//03.Import Cars

	 public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var input = JsonConvert.DeserializeObject<List<CarsDto>>(inputJson);

            List<Car> cars = new List<Car>();

            foreach (var currentCar in input)
            {
                Car car = new Car()
                {
                    Make = currentCar.Make,
                    Model = currentCar.Model,
                    TravelledDistance = currentCar.TravelledDistance
                };

                foreach (var partId in currentCar.PartsId.Distinct())
                {
                    car.PartCars.Add(new PartCar()
                    {
                        Car = car,
                        PartId = partId
                    });
                }
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();


            return $"Successfully imported {cars.Count}.";
        }

	//04.Import customers

	public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject < IEnumerable<Customer>>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

	//05.Import sales

	        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<IEnumerable<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

	//06.Export oredred customers

	public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context
                .Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToArray();

            var jsonSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
            };

            var result = JsonConvert.SerializeObject(customers, jsonSettings);

            return result;
        }

	//07.Export cars toyota

	public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new ToyotaOutputDto
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray();

            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            };

            var result = JsonConvert.SerializeObject(cars, settings);

            return result;
        }

	//08.Export local suppliers

	public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            };

            var result = JsonConvert.SerializeObject(suppliers, settings);

            return result;
        }

	//09.Export cars with list of parts

	public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
               .Cars
               .Select(c => new
               {
                   car = new CarOutputDto
                   {
                       Make = c.Make,
                       Model = c.Model,
                       TravelledDistance = c.TravelledDistance,
                   },
                   parts = c.PartCars.Select(p => new
                   {
                       Name = p.Part.Name,
                       Price = p.Part.Price.ToString("f2")
                   })
               })
               .ToArray();

            

            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            var result = JsonConvert.SerializeObject(cars, settings);

            return result;
        }

	//10.Export sales by customer

	public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context
                .Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(f => f.Part.Price))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToArray();

            DefaultContractResolver resolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = resolver
            };

            var result = JsonConvert.SerializeObject(customers, settings);

            return result;
        }
    }
}