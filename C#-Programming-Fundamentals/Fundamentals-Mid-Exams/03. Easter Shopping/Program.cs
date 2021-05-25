using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace _3._Easter_Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shops = Console.ReadLine()
                .Split()
                .ToList();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                string cmd = command[0];

                if (cmd == "Include")
                {
                    shops.Add(command[1]);
                }
                else if (cmd == "Visit")
                {
                    string place = command[1];
                    int number = int.Parse(command[2]);

                    if (number <= shops.Count)
                    {
                        if (place == "first")
                        {
                            shops.RemoveRange(0, number);
                        }
                        else if (place == "last")
                        {
                            shops.RemoveRange(shops.Count - number, number);
                        }
                    }

                }
                else if (cmd == "Prefer")
                {
                    int index1 = int.Parse(command[1]);
                    int index2 = int.Parse(command[2]);

                    if (index1 >= 0 && index1 < shops.Count &&
                        index2 >= 0 && index2 < shops.Count &&
                        index1 != index2)
                    {
                        string firstShop = shops[index1];
                        string secondShop = shops[index2];
                        shops[index1] = secondShop;
                        shops[index2] = firstShop;
                    }

                }
                else if (cmd == "Place")
                {
                    string shop = command[1];
                    int index = int.Parse(command[2]);
                    if (index >= 0 && index < shops.Count)
                    {
                        shops.Insert(index + 1, shop);
                    }
                }
            }

            Console.WriteLine("Shops left:");
            Console.WriteLine(string.Join(" ", shops));
        }
    }
}
