using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    class Truck : Vehicle
    {
        private const double AirCondConsumption = 1.6;
        public Truck(double fuelQuantity, double fuelConsumpion)
            : base(fuelQuantity, fuelConsumpion)
        {
        }
        public override string Drive(double distance)
        {
            double consumption = this.FuelConsumption + AirCondConsumption;
            double neededFuel = distance * consumption;

            if (FuelQuantity > neededFuel)
            {
                FuelQuantity -= neededFuel;
                return $"{nameof(Truck)} travelled {distance} km";
            }
            return $"{nameof(Truck)} needs refueling";
        }

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel * 0.95);
        }
    }
}
