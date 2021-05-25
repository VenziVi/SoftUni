using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();
            Queue<string> costumers = new Queue<string>();

            while (name != "End")
            {
                if (name != "Paid")
                {
                    costumers.Enqueue(name);
                }
                else if (name == "Paid")
                {
                    int costumerCount = costumers.Count;

                    for (int i = 0; i < costumerCount; i++)
                    {
                        Console.WriteLine(costumers.Dequeue());
                    }
                }

                name = Console.ReadLine();
            }

            Console.WriteLine($"{costumers.Count} people remaining.");
        }
    }
}
