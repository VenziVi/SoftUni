using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammal
{
    public class Mouse : Mammal
    {
        private const double MouseModifier = 0.1;

        private static HashSet<string> mouseFood = new HashSet<string>
        {
            nameof(Vegetable),
            nameof(Fruit)
        };

        public Mouse(string name, double weight, int foodEaten, string livingRegion)
            : base(name, weight, foodEaten, mouseFood, MouseModifier, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
