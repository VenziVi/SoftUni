using System;
using System.Collections.Generic;
using System.Linq;

namespace Special_Cars
{
     class Program
    {
        static void Main(string[] args)
        {

            List<Car> listCars = new List<Car>();
            List<Tires[]> tiresList = new List<Tires[]>();
            List<Engine> engineList = new List<Engine>();
            List<double> pressureSums = new List<double>();

            string tireInput = Console.ReadLine();
            while (tireInput != "No more tires")
            {
                //2 2.6 3 1.6 2 3.6 3 1.6
                string[] tyresInfo = tireInput.Split();
                double tirePressureSum = 0;
                Tires[] tires = new Tires[4]
                {
                        new Tires(int.Parse(tyresInfo[0]), double.Parse(tyresInfo[1])),
                        new Tires(int.Parse(tyresInfo[2]), double.Parse(tyresInfo[3])),
                        new Tires(int.Parse(tyresInfo[4]), double.Parse(tyresInfo[5])),
                        new Tires(int.Parse(tyresInfo[6]), double.Parse(tyresInfo[7])),
                };

                tirePressureSum = double.Parse(tyresInfo[1]) + double.Parse(tyresInfo[3]) + double.Parse(tyresInfo[5]) + double.Parse(tyresInfo[7]);
                pressureSums.Add(tirePressureSum);
                tiresList.Add(tires);

                tireInput = Console.ReadLine();
            }

            string engineInput = Console.ReadLine();
            while (engineInput != "Engines done")
            {
                string[] engineInfo = engineInput.Split();

                Engine engine = new Engine(int.Parse(engineInfo[0]), double.Parse(engineInfo[1]));
                engineList.Add(engine);

                engineInput = Console.ReadLine();
            }

            string carInput = Console.ReadLine();
            while (carInput != "Show special")
            {
                //{ make} { model} { year} { fuelquantity} { fuelconsumption} { engineindex} { tiresindex}
                string[] carInfo = carInput.Split();
                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[6]);

                Engine engine = engineList[engineIndex];
                Tires[] tires = tiresList[tiresIndex];
                double totalPressure = pressureSums[tiresIndex];

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tires, totalPressure);

                listCars.Add(car);

                carInput = Console.ReadLine();
            }

            foreach (Car car in listCars)
            {

                if (car.Year >= 2017 && car.Engine.HorsePower >= 330 && car.TotalPressure >= 9 && car.TotalPressure <= 10)
                {
                    car.Drive(20);

                    Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}\n" +
                        $"HorsePowers: {car.Engine.HorsePower}\nFuelQuantity: {car.FuelQuantity}");
                }
            }
        }
    }
}
