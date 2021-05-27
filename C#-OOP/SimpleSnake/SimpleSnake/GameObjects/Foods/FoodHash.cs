using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class FoodHash : Food
    {
        private const char FoodSymbol = '#';
        private const ConsoleColor CurrentColor = ConsoleColor.Blue;
        private const int Points = 3;
        public FoodHash(Wall wall) 
            : base(wall, FoodSymbol, Points, CurrentColor)
        {
        }
    }
}
