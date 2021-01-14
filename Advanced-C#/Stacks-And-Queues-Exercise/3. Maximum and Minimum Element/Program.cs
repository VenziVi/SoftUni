using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] queries = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int cmd = queries[0];

                if (cmd == 1)
                {
                    stack.Push(queries[1]);
                }
                else if (cmd == 2)
                {
                    stack.Pop();
                }
                else if (cmd == 3)
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.ToArray().Max());
                    }
                }
                else if (cmd == 4)
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.ToArray().Min());
                    }
                }
            }

            Console.WriteLine(string.Join(", ", stack.ToArray()));
        }
    }
}
