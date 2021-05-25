using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammal.Feline
{
    public class Tiger : Feline
    {
        private const double TigerModifier = 1;

        private static HashSet<string> tigerFood = new HashSet<string>
        {
            nameof(Meat)
        };

        public Tiger(string name, double weight, int foodEaten,string livingRegion, string breed) 
            : base(name, weight, foodEaten, tigerFood, TigerModifier, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
