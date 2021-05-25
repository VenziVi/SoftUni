using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer, double travelledDistance)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = travelledDistance;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }


        public void Drive(double dictanse)
        {
            double neededFuel = FuelConsumptionPerKilometer * dictanse;
            if (neededFuel <= FuelAmount)
            {
                TravelledDistance += dictanse;
                FuelAmount -= neededFuel;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public string CarInfo()
        {
            return $"{Model} {FuelAmount:f2} {TravelledDistance}";
        }
    }
}
