using System;
using System.Collections.Generic;
using System.Text;

namespace TemplatePattern
{
    public class TwelvGrain : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Mixing ingredians for 12-grain bread!");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking 12-grain bread (20 min)!");
        }

    }
}
