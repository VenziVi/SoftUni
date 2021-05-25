using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double AirCondConsumption = 0.9;
        public Car(double fuelQuantity, double fuelConsumpion)
            :base(fuelQuantity, fuelConsumpion)
        {
        }

        public override string Drive(double distance)
        {
            double consumption = this.FuelConsumption + AirCondConsumption;
            double neededFuel = distance * consumption;

            if (FuelQuantity > neededFuel)
            {
                FuelQuantity -= neededFuel;
                return $"{nameof(Car)} travelled {distance} km";
            }
            return $"{nameof(Car)} needs refueling";
        }

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel);
        }
    }
}
