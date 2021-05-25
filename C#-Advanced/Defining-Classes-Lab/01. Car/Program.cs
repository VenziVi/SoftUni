using System;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "VW";
            car.Model = "MK3";
            car.Year = 2005;

            Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}");
        }
    }
}
