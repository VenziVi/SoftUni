using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> ordersQueue = new Queue<int>(orders);

            Console.WriteLine(ordersQueue.ToArray().Max());

            while (ordersQueue.Count > 0)
            {
                int currentOrder = ordersQueue.Peek();

                if (currentOrder <= food)
                {
                    ordersQueue.Dequeue();
                    food -= currentOrder;
                }
                else
                {
                    break;
                }
            }

            if (ordersQueue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ",ordersQueue.ToArray())}");
            }

        }
    }
}
