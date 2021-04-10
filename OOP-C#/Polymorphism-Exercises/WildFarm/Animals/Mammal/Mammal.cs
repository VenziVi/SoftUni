using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammal
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, int foodEaten, HashSet<string> allowedFood, double weghtModifier, string livingRegion) 
            : base(name, weight, foodEaten, allowedFood, weghtModifier)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }

        public abstract override string ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
