using System;
using System.Collections.Generic;
using System.Text;

namespace TemplatePattern
{
    public class WholeWheat : Bread
    {
        public override void Bake()
        {
            Console.WriteLine($"Baking {this.GetType().Name} bread for 25 min!");
        }

        public override void MixIngredients()
        {
            Console.WriteLine($"Gathering ingridians for {this.GetType().Name} bread!");
        }
    }
}
