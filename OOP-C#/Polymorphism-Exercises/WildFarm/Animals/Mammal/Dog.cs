using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammal
{
    public class Dog : Mammal
    {
        private const double DogModifier = 0.4;

        private static HashSet<string> dogFood = new HashSet<string>
        {
            nameof(Meat)
        };

        public Dog(string name, double weight, int foodEaten, string livingRegion) 
            : base(name, weight, foodEaten, dogFood, DogModifier, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
