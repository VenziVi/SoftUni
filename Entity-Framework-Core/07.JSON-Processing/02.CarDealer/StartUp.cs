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
    }
}