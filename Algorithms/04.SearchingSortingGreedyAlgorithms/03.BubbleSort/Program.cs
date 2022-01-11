using System;
using System.Linq;

namespace _03.BubbleSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var sortedArr = Bubble(input);
            Console.WriteLine(string.Join(" ", sortedArr));
        }

        private static int[] Bubble(int[] input)
        {
            bool isSorted = false;
            var sortedEl = 0;

            while (!isSorted)
            {
                isSorted = true;

                for (int i = 1; i < input.Length - sortedEl; i++)
                {
                    if (input[i - 1] > input[i])
                    {
                        Swap(input, i - 1, i);
                        isSorted = false;
                    }
                }

                sortedEl++;
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
