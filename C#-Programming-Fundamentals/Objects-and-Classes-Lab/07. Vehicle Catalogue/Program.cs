using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _08._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();

            string info = Console.ReadLine();

            while (info != "end")
            {
                string[] vehicleInfo = info.Split('/');

                if (vehicleInfo[0] == "Car")
                {
                    Car car = new Car(vehicleInfo[1], vehicleInfo[2], int.Parse(vehicleInfo[3]));
                    cars.Add(car);
                    CatalogVehicle catalog = new CatalogVehicle(cars);


                }
                else if (vehicleInfo[0] == "Truck")
                {
                    Truck truck = new Truck(vehicleInfo[1], vehicleInfo[2], int.Parse(vehicleInfo[3]));
                    trucks.Add(truck); 
                    CatalogVehicle catalog = new CatalogVehicle(trucks);
                }

                info = Console.ReadLine();
            }
            if (cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                Console.WriteLine(string.Join(Environment.NewLine, cars.OrderBy(x => x.Model)));
            }
            if (trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                Console.WriteLine(string.Join(Environment.NewLine, trucks.OrderBy(x => x.Model)));
            }

            
        }
    }

    class Car
    {
        public Car(string brand, string model, int horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }

        public string Brand { get; set; }

        public  string Model { get; set; }

        public  int HorsePower { get; set; }

        public override string ToString()
        {
            return ($"{Brand}: {Model} - {HorsePower}hp").ToString().TrimEnd();
        }
    }

    class Truck
    {
        public Truck(string brand, string model, int weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Weight { get; set; }

        public override string ToString()
        {
            return ($"{Brand}: {Model} - {Weight}kg").ToString().TrimEnd();
        }

    }

    class CatalogVehicle
    {
        public CatalogVehicle(List<Car> cars)
        {
            Cars = cars;
        }

        public CatalogVehicle(List<Truck> trucks)
        {
            Trucks = trucks;
        }

        public List<Car> Cars { get; set; }

        public List<Truck> Trucks { get; set; }

    }
}
