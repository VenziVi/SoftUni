using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammal.Feline
{
    public class Cat : Feline
    {
        private const double CatModifier = 0.3;

        private static HashSet<string> catFood = new HashSet<string>
        {
            nameof(Meat),
            nameof(Vegetable)
        };

        public Cat(string name, double weight, int foodEaten, string livingRegion, string breed) 
            : base(name, weight, foodEaten, catFood, CatModifier, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }    
    }
}
