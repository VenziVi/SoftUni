using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = new Dictionary<string, List<int>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] car = Console.ReadLine().Split("|");
                string model = car[0];
                int mileage = int.Parse(car[1]);
                int fuel = int.Parse(car[2]);

                cars.Add(model, new List<int> { mileage, fuel });
            }

            string input = Console.ReadLine();

            while (input != "Stop")
            {
                string[] command = input.Split(" : ");
                string cmd = command[0];
                string car = command[1];

                if (cmd == "Drive")
                {
                    int distance = int.Parse(command[2]);
                    int fuel = int.Parse(command[3]);

                    if (cars[car][1] < fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        cars[car][1] -= fuel;
                        cars[car][0] += distance;

                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }
                    if (cars[car][0] >= 100000)
                    {
                        Console.WriteLine($"Time to sell the {car}!");
                        cars.Remove(car);
                    }

                }
                else if (cmd == "Refuel")
                {
                    int fuel = int.Parse(command[2]);
                    int fuelInTank = cars[car][1];
                    cars[car][1] += fuel;

                    if (cars[car][1] > 75)
                    {
                        cars[car][1] = 75;

                        Console.WriteLine($"{car} refueled with {75 - fuelInTank} liters");
                    }
                    else
                    {
                        Console.WriteLine($"{car} refueled with {fuel} liters");
                    }
                }
                else if (cmd == "Revert")
                {
                    int km = int.Parse(command[2]);
                    cars[car][0] -= km;

                    if (cars[car][0] < 10000)
                    {
                        cars[car][0] = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{car} mileage decreased by {km} kilometers");
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var car in cars.OrderByDescending(x => x.Value[0])
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value[0]} kms, Fuel in the tank: {car.Value[1]} lt.");
            }
        }
    }
}
