using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] children = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            Queue<string> potato = new Queue<string>(children);
            int potatoTosses = 0;

            while (potato.Count > 1)
            {
                potatoTosses++;
                string kid = potato.Dequeue();

                if (n == potatoTosses)
                {
                    potatoTosses = 0;
                    Console.WriteLine($"Removed {kid}");
                }
                else
                {
                    potato.Enqueue(kid);
                }
            }

            Console.WriteLine($"Last is {potato.Dequeue()}");
        }
    }
}
