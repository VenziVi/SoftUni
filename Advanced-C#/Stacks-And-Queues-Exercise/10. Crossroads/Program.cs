using System;
using System.Collections.Generic;
using System.Linq;

namespace _12_Cups_and_Bottles 
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] bottlesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int wastedWater = 0;
            int cup = 0;
            Queue<int> cups = new Queue<int>(cupsInput);
            Stack<int> bottles = new Stack<int>(bottlesInput);

            while (true)
            {
                int waterLeft = 0;

                int bottle = 0;
                if (bottles.Any())
                {
                    bottle = bottles.Peek();
                }
                else
                {
                    break;
                }

                if (cup <= 0)
                {
                    if (cups.Any())
                    {
                        cup = cups.Peek();
                    }
                    else
                    {
                        break;
                    }
                }


                if (bottle >= cup)
                {
                    waterLeft = bottle - cup;
                    bottles.Pop();
                    cups.Dequeue();
                    cup = 0;
                }
                else
                {
                    cup = cup - bottle;
                    bottles.Pop();
                }

                wastedWater += waterLeft;
            }

            if (bottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else if (cups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
