using System;
using System.Collections.Generic;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> productList = new Dictionary<string, List<double>>();

                string line = Console.ReadLine();

            while (line != "buy")
            {
                string[] info = line.Split();
                string product = info[0];
                double price = double.Parse(info[1]);
                double quantity = double.Parse(info[2]);

                if (productList.ContainsKey(product))
                {
                    productList[product][0] = price;
                    productList[product][1] += quantity;
                }
                else
                {
                    productList.Add(product, new List<double> {price, quantity});
                }

                line = Console.ReadLine();
            }

            foreach (var product in productList)
            {
                double totalPrice = product.Value[0] * product.Value[1];
                Console.WriteLine($"{product.Key} -> {totalPrice:f2}");
            }
        }
    }
}
