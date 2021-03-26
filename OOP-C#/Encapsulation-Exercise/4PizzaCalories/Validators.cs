using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public static class Validators
    {
        public static void RangeValidator(int min, int max, int num, string massage)
        {
            if (num < min ||
                    num > max)
            {
                throw new ArgumentException(massage);
            }
        }

        public static void TypeValidator(HashSet<string> typeName, string value, string massage)
        {
            if (!typeName.Contains(value))
            {
                throw new ArgumentException(massage);
            }
        }

    }
}
