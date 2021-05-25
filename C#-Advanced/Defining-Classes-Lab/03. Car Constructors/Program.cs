using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string model = Console.ReadLine();
            string make = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            Car firstCar = new Car();
            Console.WriteLine(firstCar.WhoAmI());
            Car secondCar = new Car(make, model, year);
            Console.WriteLine(secondCar.WhoAmI());
            Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);
            Console.WriteLine(thirdCar.WhoAmI());
        }
    }
}