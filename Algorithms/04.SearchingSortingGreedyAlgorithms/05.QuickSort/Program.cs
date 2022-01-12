using System;
using System.Linq;

namespace _05.QuickSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Quick(input, 0, input.Length - 1);
            Console.WriteLine(string.Join(" ", input));
        }

        private static void Quick(int[] input, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var pivot = start;
            var left = start + 1;
            var right = end;

            while (left <= right)
            {
                if (input[left] > input[pivot] && input[right] < input[pivot])
                {
                    Swap(input, left, right);
                }

                if (input[left] <= input[pivot])
                {
                    left += 1;
                }

                if (input[right] >= input[pivot])
                {
                    right -= 1;
                }
            }

            Swap(input, pivot, right);

            bool isLeftSmaller = right - 1 - start < end - (right + 1);

            if (isLeftSmaller)
            {
                Quick(input, start, right - 1);
                Quick(input, right + 1, end);
            }
            else
            {
                Quick(input, right + 1, end);
                Quick(input, start, right - 1);
            }
        }


        private static void Swap(int[] input, int index, int min)
        {
            var temp = input[index];
            input[index] = input[min];
            input[min] = temp;
        }
    }
}
