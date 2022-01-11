using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SelectionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var sortedArr = Selection(input);
            Console.WriteLine(string.Join(" ", sortedArr));
        }

        private static int[] Selection(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                var min = i;

                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[j] < input[min])
                    {
                        min = j;
                    }
                }

                Swap(input, i, min);
            }

            return input;
        }

        private static void Swap(int[] input, int index, int min)
        {
            var temp = input[index];
            input[index] = input[min];
            input[min] = temp;
        }
    }
}
