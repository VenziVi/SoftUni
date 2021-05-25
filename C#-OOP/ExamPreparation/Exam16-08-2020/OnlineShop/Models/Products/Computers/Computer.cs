using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;
        private double overallPerformance;
        private decimal price;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
            this.overallPerformance = overallPerformance;
            this.price = price;
        }

        public override double OverallPerformance 
        {
            get
            {
                if (components.Count == 0)
                {
                    return this.overallPerformance;
                }

                double sum = 0;
                foreach (var component in this.components)
                {
                    sum += component.OverallPerformance;
                }
                double average = sum / components.Count;
                return average;
            } 
        }

        public override decimal Price
        {
            get
            {
                decimal totalPrice = 0;
                totalPrice += components.Sum(s => s.Price);
                totalPrice += peripherals.Sum(p => p.Price);
                return totalPrice + this.price;
            }
        }

        public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.AsReadOnly();

        public void AddComponent(IComponent component)
        {
            if (components.Contains(component))
            {
                throw new ArgumentException(string.Format(Common.Constants.ExceptionMessages.ExistingComponent, 
                    component.GetType().Name, this.GetType().Name, this.Id));
            }

            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Contains(peripheral))
            {
                throw new ArgumentException(string.Format(Common.Constants.ExceptionMessages.ExistingPeripheral,
                   peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            var currComponent = components.FirstOrDefault(c =>c.GetType().Name == componentType);

            if (currComponent == null)
            {
                throw new ArgumentException(string.Format(Common.Constants.ExceptionMessages.NotExistingComponent,
                   componentType, this.GetType().Name, this.Id));
            }

            components.Remove(currComponent);
            return currComponent;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var currPeriferial = peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);

            if (currPeriferial == null)
            {
                throw new ArgumentException(string.Format(Common.Constants.ExceptionMessages.NotExistingPeripheral,
                   peripheralType, this.GetType().Name, this.Id));
            }

            peripherals.Remove(currPeriferial);
            return currPeriferial;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({this.components.Count}):");

            foreach (var component in this.components)
            {
                sb.AppendLine($"  {component.ToString()}");
            }

            double sum = 0;
            double average = 0;
            //average = peripherals.Average(p => p.OverallPerformance);
            foreach (var periferia in this.peripherals)
            {
                sum += periferia.OverallPerformance;
            }
            if (sum == 0)
            {
                average = 0;
            }
            else
            {
                average = sum / this.peripherals.Count;
            }

            sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({average:f2}):");

            foreach (var periferia in this.peripherals)
            {
                sb.AppendLine($"  {periferia.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
