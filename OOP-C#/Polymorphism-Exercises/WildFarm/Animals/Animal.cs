using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public abstract class Animal
    {
        protected Animal(string name, double weight, int foodEaten, HashSet<string> allowedFood, double weghtModifier)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = foodEaten;
            this.AllowedFood = allowedFood;
            this.WeightModifier = weghtModifier;
        }

        private HashSet<string> AllowedFood { get; set; }

        private double WeightModifier { get; set; }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public abstract string ProduceSound();

        public void Eat(Food food)
        {
            if (this.AllowedFood.Contains(food.GetType().Name))
            {
                this.FoodEaten += food.Quantity;

                this.Weight += this.WeightModifier * food.Quantity;
            }
            else
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public abstract override string ToString();
       
    }
}
