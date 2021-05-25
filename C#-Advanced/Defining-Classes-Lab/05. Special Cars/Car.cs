using System;
using System.Collections.Generic;
using System.Text;

namespace Special_Cars
{
    public class Tires
    {
        public Tires(int year, double pressure)
        {
            Year = year;
            Pressure = pressure;
        }
        public int Year { get; set; }

        public double Pressure { get; set; }
    }

    public class Engine
    {
        public Engine(int horsePower, double cubicCapacity)
        {
            HorsePower = horsePower;
            CubicCapacity = cubicCapacity;
        }

        public int HorsePower { get; set; }

        public double CubicCapacity { get; set; }
    }

    public class Car
    {

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tires[] tires, double totalPressure)
            
        {
            Make = make;
            Model = model;
            Year = year;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            Engine = engine;
            Tires = tires;
            TotalPressure = totalPressure;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public Engine Engine { get; set; }

        public Tires[] Tires { get; set; }

        public double TotalPressure { get; set; }

        public void Drive(double distance)
        {
            double fuelNeeded = (distance * FuelConsumption) / 100;
            if (FuelQuantity - fuelNeeded > 0)
            {
                FuelQuantity -= fuelNeeded;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI() 
        {
            return $"Make: {Make}\nModel: {Model}\nYear: {Year}\nFuel: {FuelQuantity:F2}L";
        }

    }
}
