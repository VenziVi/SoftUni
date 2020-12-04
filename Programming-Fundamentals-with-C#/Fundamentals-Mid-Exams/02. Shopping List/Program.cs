using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> products = Console.ReadLine().Split('!').ToList();

            string command = Console.ReadLine();

            while (command != "Go Shopping!")
            {
                string[] cmdArg = command.Split().ToArray();

                string cmd = cmdArg[0];
                string product = cmdArg[1];

                if (cmd == "Urgent")
                {
                    if (!products.Contains(product))
                    {
                        products.Insert(0, product);
                    }

                }

                if (cmd == "Unnecessary")
                {
                    products.Remove(product);
                }

                if (cmd == "Correct")
                {
                    for (int i = 0; i < products.Count; i++)
                    {
                        if (product == products[i])
                        {
                            products[i] = cmdArg[2];
                        }

                    }
                }

                if (cmd == "Rearrange")
                {
                    for (int i = 0; i < products.Count; i++)
                    {
                        if (product == products[i])
                        {
                            products.Remove(products[i]);
                            products.Insert(products.Count, product);
                        }

                    }
                }
                             
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", products).TrimEnd());
        }
    }
}
