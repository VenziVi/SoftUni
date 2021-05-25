﻿using System;
using System.Linq;

namespace _07._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string field = Console.ReadLine();
            var bomb = 0;

            for (int i = 0; i < field.Length; i++)
            {
                var currentChar = field[i];

                if (currentChar == '>')
                {
                    bomb += int.Parse(field[i + 1].ToString());
                    continue;
                }

                if (bomb > 0)
                {
                    field = field.Remove(i, 1);
                    i--;
                    bomb--;
                }
            }

            Console.WriteLine(field);
            
        }
    }
}
