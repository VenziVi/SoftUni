using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Bird
{
    public class Owl : Bird
    {
        private const double OlwModifier = 0.25;

        private static HashSet<string> owlFood = new HashSet<string>
        {
            nameof(Meat)
        };

        public Owl(string name, double weight, int foodEaten, double wingSize) 
            : base(name, weight, foodEaten, owlFood, OlwModifier, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
