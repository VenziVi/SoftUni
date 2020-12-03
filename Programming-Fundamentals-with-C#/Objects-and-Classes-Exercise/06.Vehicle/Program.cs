using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.Vehicle
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> catalogue = new List<Vehicle>();
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] cmdArg = command.Split();
                string type = cmdArg[0].ToLower();
                string model = cmdArg[1];
                string color = cmdArg[2].ToLower();
                int horsePower = int.Parse(cmdArg[3]);

                Vehicle currentVehicle = new Vehicle(type, model, color, horsePower);
                catalogue.Add(currentVehicle);

                command = Console.ReadLine();
            }

            string SecondCommand = Console.ReadLine();

            while (SecondCommand != "Close the Catalogue")
            {
                string modelType = SecondCommand;

                Vehicle printCar = catalogue.First(x => x.Model == modelType);
                Console.WriteLine(printCar);

                SecondCommand = Console.ReadLine();
            }

            List<Vehicle> cars = catalogue.Where(x => x.Type == "car").ToList();
            List<Vehicle> trucks = catalogue.Where(x => x.Type == "truck").ToList();

            double carsHp = cars.Sum(x => x.HorsePower);
            double trucksHp = trucks.Sum(x => x.HorsePower);

            double avgCarsHp = 0.00;
            double avgTrucksHp = 0.00;

            if (cars.Count > 0)
            {
                avgCarsHp = carsHp / cars.Count;
            }
            if (trucks.Count > 0)
            {
                avgTrucksHp = trucksHp / trucks.Count;
            }

            Console.WriteLine($"Cars have average horsepower of: {avgCarsHp:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {avgTrucksHp:f2}.");
        }
    }

    class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }

        public string Type { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int HorsePower { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Type: {(Type == "car" ? "Car" : "Truck")}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"Color: {Color}");
            sb.AppendLine($"Horsepower: {HorsePower}");

            return sb.ToString().TrimEnd();
        }
    }
}
