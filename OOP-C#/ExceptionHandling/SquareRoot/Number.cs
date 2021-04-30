using System;
using System.Collections.Generic;
using System.Text;

namespace SquareRoot
{
    class Number
    {
        private int num;

        public Number(int num)
        {
            Num = num;
        }
        public int Num 
        {
            get => num;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid number!");
                }

                num = value;
            }
        }

        public int GetSquare()
        {
            return num * num;
        }
    }
}
