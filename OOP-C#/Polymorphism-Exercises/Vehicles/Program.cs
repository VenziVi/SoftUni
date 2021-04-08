using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var carInput = Console.ReadLine().Split();
            Vehicle car = new Car(
                double.Parse(carInput[1]),
                double.Parse(carInput[2]));

            var truckInput = Console.ReadLine().Split();
            Vehicle truck = new Truck(
                double.Parse(truckInput[1]),
                double.Parse(truckInput[2]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split();

                var command = line[0];
                var vehicle = line[1];

                if (command == "Drive")
                {
                    double distance = double.Parse(line[2]);

                    if (vehicle == nameof(Car))
                    {
                        Console.WriteLine(car.Drive(distance));
                    }
                    else if (vehicle == nameof(Truck))
                    {
                        Console.WriteLine(truck.Drive(distance));
                    }
                }
                else if (command == "Refuel")
                {
                    double fuel = double.Parse(line[2]);

                    if (vehicle == nameof(Car))
                    {
                        car.Refuel(fuel);
                    }
                    else if (vehicle == nameof(Truck))
                    {
                        truck.Refuel(fuel);
                    }
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
