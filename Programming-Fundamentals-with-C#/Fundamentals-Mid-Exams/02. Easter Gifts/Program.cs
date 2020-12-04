using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace _2._Easter_Gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> gifts = Console.ReadLine()
                .Split()
                .ToList();

            string command = Console.ReadLine();

            while (command != "No Money")
            {
                string[] line = command.Split();
                string cmd = line[0];
                string gift = line[1];

                if (cmd == "OutOfStock")
                {
                    for (int i = 0; i < gifts.Count; i++)
                    {
                        if (gifts[i] == gift)
                        {
                            gifts.Remove(gifts[i]);
                            gifts.Insert(i, "None");
                        }
                    }
                }
                else if (cmd == "Required")
                {
                    int index = int.Parse(line[2]);
                    if (index >= 0 && index < gifts.Count)
                    {
                        gifts[index] = gift;
                    }
                }
                else if (cmd == "JustInCase")
                {
                    gifts[gifts.Count - 1] = gift;
                }

                command = Console.ReadLine();
            }

            gifts.RemoveAll(x => x == "None");
            Console.WriteLine(string.Join(" ", gifts));
        }
    }
}
