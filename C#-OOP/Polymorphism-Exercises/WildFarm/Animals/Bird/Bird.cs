using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Bird
{
    public abstract class Bird : Animal
    {
        public Bird(string name, 
            double weight, 
            int foodEaten, 
            HashSet<string> allowedFood, 
            double weghtModifier, 
            double wingSize) 
            : base(name, weight, foodEaten, allowedFood, weghtModifier)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; private set; }

        public abstract override string ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }        
    }
}
