using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();
                string model = info[0];
                int engineSpeed = int.Parse(info[1]);
                int enginePower = int.Parse(info[2]);
                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(info[3]);
                string cargoType = info[4];
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                double tire1Pressure = double.Parse(info[5]);
                int tire1Year = int.Parse(info[6]);
                Tires tire1 = new Tires(tire1Pressure, tire1Year);                

                double tire2Pressure = double.Parse(info[7]);
                int tire2Year = int.Parse(info[8]);
                Tires tire2 = new Tires(tire2Pressure, tire2Year);

                double tire3Pressure = double.Parse(info[9]);
                int tire3Year = int.Parse(info[10]);
                Tires tire3 = new Tires(tire3Pressure, tire3Year);

                double tire4Pressure = double.Parse(info[11]);
                int tire4Year = int.Parse(info[12]);
                Tires tire4 = new Tires(tire4Pressure, tire4Year);

                List<Tires> tires = new List<Tires> {tire1, tire2, tire3, tire4 };

                Car car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                List<Car> fragileCars = new List<Car>();
                fragileCars = cars.Where(c => c.Cargo.CargoType == "fragile")
                    .Where(c => c.Tires.Any(p => p.TirePressure < 1)).ToList();

                foreach (Car car in fragileCars)
                {
                    Console.WriteLine(car.Model);
                }

                //cars.Where(c => c.Cargo.CargoType == "fragile").Where(c => c.Tires.Any(t => t.TirePressure < 1))
                //.Select(c => c.Model).ToList().ForEach(m => Console.WriteLine(m));

            }
            else if (command == "flamable")
            {
                List<Car> flamableCars = new List<Car>();
                flamableCars = cars.Where(c => c.Cargo.CargoType == "flamable")
                    .Where(c => c.Engine.EnginePower > 250).ToList();

                foreach (Car car in flamableCars)
                {
                    Console.WriteLine(car.Model);
                }

                //cars.Where(c => c.Cargo.CargoType == "flamable").Where(c => c.Engine.EnginePower > 250)
                //.Select(c => c.Model).ToList().ForEach(m => Console.WriteLine(m));
            }
        }
    }
}
