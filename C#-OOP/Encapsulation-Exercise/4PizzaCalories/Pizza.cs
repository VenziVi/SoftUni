using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int minNameLenght = 1;
        private const int maxnameLenght = 15;
        private const int minTopping = 0;
        private const int maxTopping = 10;

        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validators.RangeValidator(
                    minNameLenght,
                    maxnameLenght,
                    value.Length,
                    $"Pizza name should be between {minNameLenght} and {maxnameLenght} symbols.");
               
                this.name = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count == maxTopping)
            {
                throw new InvalidOperationException($"Number of toppings should be in range [{minTopping}..{maxTopping}].");
            }
            toppings.Add(topping);
        }

        public double PizzaCalories
        {
            get => this.dough.DoughCalories() + GetToppingsCalories();
        }

        private double GetToppingsCalories()
        {
            double toppingsCalories = 0;
            foreach (var topping in toppings)
            {
                toppingsCalories += topping.ToppingCalories;
            }
            return toppingsCalories;
        }
    }
}
