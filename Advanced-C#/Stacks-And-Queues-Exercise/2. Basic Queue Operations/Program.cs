using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] values = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> numsStack = new Queue<int>();
            int enque = values[0];
            int deque = values[1];
            int x = values[2];

            for (int i = 0; i < enque; i++)
            {
                numsStack.Enqueue(numbers[i]);
            }

            for (int i = 0; i < deque; i++)
            {
                numsStack.Dequeue();
            }

            if (numsStack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (numsStack.Count > 0)
                {
                    int[] findMin = numsStack.ToArray();
                    int minNum = findMin.Min();
                    Console.WriteLine(minNum);
                }
                else
                {
                    Console.WriteLine("0");

                }
            }
        }
    }
}

