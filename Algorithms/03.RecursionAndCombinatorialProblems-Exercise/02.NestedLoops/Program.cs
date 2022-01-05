using System;
using System.Collections.Generic;

namespace _02.NestedLoops
{
    internal class Program
    {
        private static int[] result;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            result = new int[n];

            Variation(0);
        }

        private static void Variation(int index)
        {
            if (index >= result.Length)
            {
                Console.WriteLine(string.Join(" ", result));
                return;
            }

            for (int i = 1; i <= result.Length; i++)
            {
                result[index] = i;
                Variation(index + 1);
            }
        }
    }
}
