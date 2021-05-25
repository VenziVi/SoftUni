using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumpion)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumpion;
        }

        public double FuelQuantity { get; set; }

        public double FuelConsumption  { get; set; }

        public abstract string Drive(double distance);

        public virtual void Refuel(double fuel)
        {
            FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return ($"{this.GetType().Name}: {FuelQuantity:f2}");
        }
    }
}
