using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carInput = Console.ReadLine().Split();
                string make = carInput[0];
                double fuelAmount = double.Parse(carInput[1]);
                double fuelPerKm = double.Parse(carInput[2]);
                Car car = new Car(make, fuelAmount, fuelPerKm, 0);
                cars.Add(car);
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] splited = command.Split();
                string cmd = splited[0];
                string currCar = splited[1];
                double km = double.Parse(splited[2]);

                if (cmd == "Drive")
                {
                    foreach (Car car in cars)
                    {
                        if (car.Model == currCar)
                        {
                            car.Drive(km);
                        }
                    }
                }
                
                command = Console.ReadLine();
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car.CarInfo());
            }
        }
    }
}
