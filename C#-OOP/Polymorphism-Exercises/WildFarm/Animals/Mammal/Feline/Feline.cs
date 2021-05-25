using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammal.Feline
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight, int foodEaten, HashSet<string> allowedFood, double weghtModifier, string livingRegion, string breed) 
            : base(name, weight, foodEaten, allowedFood, weghtModifier, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; private set; }

        public abstract override string ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
