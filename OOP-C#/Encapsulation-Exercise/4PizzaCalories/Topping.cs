using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const int minWeight = 1;
        private const int maxWeight = 50;

        private string name;
        private int weight;

        public Topping(string name, int weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                string lowerValue = value.ToLower();
                HashSet<string> toppings = new HashSet<string> { "meat", "veggies", "cheese", "sauce" };
                Validators.TypeValidator(
                    toppings, 
                    lowerValue, 
                    $"Cannot place {value} on top of your pizza.");
                
                this.name = value;
            }
        }

        public int Weight
        {
            get => this.weight;
            private set
            {
                Validators.RangeValidator(
                    minWeight, 
                    maxWeight, 
                    value, 
                    $"{this.name} weight should be in the range [1..50].");

                this.weight = value;
            }
        }

        public double ToppingCalories
        {
            get => 2 * weight * GetToppingModifier();
        }

        private double GetToppingModifier()
        {

            if (this.name.ToLower() == "meat")
            {
                return 1.2;
            }

            if (this.name.ToLower() == "veggies")
            {
                return 0.8;
            }

            if (this.name.ToLower() == "cheese")
            {
                return 1.1;
            }

            return 0.9;
        }
    }
}
