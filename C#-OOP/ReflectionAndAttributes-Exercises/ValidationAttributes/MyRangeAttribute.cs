using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            if (!(obj is int))
            {
                return false;
            }

            int value = (int)obj; 

            if (value < minValue || value > maxValue)
            {
                return false;
            }

            return true;
        }
    }
}
