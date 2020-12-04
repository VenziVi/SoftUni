using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Hello__France
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] list = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            double budget = double.Parse(Console.ReadLine());

            List<double> prices = new List<double>();
            double profit = 0;
            

            for (int i = 0; i < list.Length; i++)
            {
                string[] line = list[i].Split("->");
                string product = line[0];
                double price = double.Parse(line[1]);
                double maxPrice = 0;

                if (product == "Clothes")
                {
                    maxPrice = 50;
                }
                else if (product == "Shoes")
                {
                    maxPrice = 35.00;
                }
                else if (product == "Accessories")
                {
                    maxPrice = 20.50;
                }

                if (price <= maxPrice && price <= budget)
                {
                    budget -= price;
                    profit += price * 0.4;
                    prices.Add(price * 1.4);
                }
            }

            for (int i = 0; i < prices.Count; i++)
            {
                Console.Write($"{prices[i]:f2} ");
            }

            Console.WriteLine();
            Console.WriteLine($"Profit: {profit:f2}");

            budget += prices.Sum();

            if (budget >= 150)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");    
            }
        }
    }
}
