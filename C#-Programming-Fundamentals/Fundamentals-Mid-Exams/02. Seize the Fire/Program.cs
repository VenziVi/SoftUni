using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace _2._Seize_the_Fire
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split("#", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            int water = int.Parse(Console.ReadLine());
            int waterUsed = 0;
            double effort = 0.0;
            int waterleft = water;
            List<int> extinguished = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                string[] fires = input[i].Split(" = ", StringSplitOptions.RemoveEmptyEntries);
                string type = fires[0];
                int range = int.Parse(fires[1]);

                if (type == "High")
                {
                    if (range >= 81 && range <= 125 && waterleft >= range)
                    {
                        extinguished.Add(range);
                        waterUsed += range;
                        waterleft -= range;
                        effort += range * 0.25;
                    }
                }
                else if (type == "Medium")
                {
                    if (range >= 51 && range <= 80 && waterleft >= range)
                    {
                        extinguished.Add(range);
                        waterUsed += range;
                        waterleft -= range;
                        effort += range * 0.25;
                    }
                }
                else if (type == "Low")
                {
                    if (range >= 1 && range <= 50 && waterleft >= range)
                    {
                        extinguished.Add(range);
                        waterUsed += range;
                        waterleft -= range;
                        effort += range * 0.25;
                    }
                }

            }
            Console.WriteLine("Cells:");
            for (int i = 0; i < extinguished.Count; i++)
            {
                Console.WriteLine($" - {extinguished[i]}");
            }
            Console.WriteLine($"Effort: {effort:f2}");
            Console.WriteLine($"Total Fire: {waterUsed}");

        }
    }
}
