using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                .Split(", ")
                .ToList();

            string line = Console.ReadLine();

            while (line != "Craft!")
            {
                string[] command = line.Split(" - ");
                string cmd = command[0];
                string item = command[1];

                if (cmd == "Collect")
                {
                    if (!items.Contains(item))
                    {
                        items.Add(item);
                    }
                }
                else if (cmd == "Drop")
                {
                    if (items.Contains(item))
                    {
                        items.Remove(item);
                    }
                }
                else if (cmd == "Combine Items")
                {
                    string[] combine = item.Split(":");
                    string oldItem = combine[0];
                    string newItem = combine[1];

                    if (items.Contains(oldItem))
                    {
                        for (int i = 0; i < items.Count; i++)
                        {
                            if (items[i] == oldItem)
                            {
                                items.Insert(i + 1, newItem);
                            }
                        }

                    }
                }
                else if (cmd == "Renew")
                {
                    if (items.Contains(item))
                    {
                        string newItem = item;
                        items.Remove(item);
                        items.Add(newItem);
                    }
                }
                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", items));
        }
    }
}
