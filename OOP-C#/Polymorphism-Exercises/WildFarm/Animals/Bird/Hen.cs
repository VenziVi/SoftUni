using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Bird
{
    public class Hen : Bird
    {
        private const double HenModifier = 0.35;

        private static HashSet<string> henFood = new HashSet<string>
        {
            nameof(Fruit),
            nameof(Meat),
            nameof(Seeds),
            nameof(Vegetable)
        };

        public Hen(string name, double weight, int foodEaten, double wingSize) 
            : base(name, weight, foodEaten, henFood, HenModifier, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
