using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> numsQueue = new Queue<int>(nums);
            List<int> n = new List<int>();

            while (numsQueue.Count > 0)
            {
                int number = numsQueue.Dequeue();

                if (number % 2 == 0)
                {
                    n.Add(number);
                }
            }

            Console.WriteLine(string.Join(", ", n));
        }
    }
}
