using System;
using System.Linq;

namespace _04.InsertionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var sortedArr = Insertion(input);
            Console.WriteLine(string.Join(" ", sortedArr));
        }

        private static int[] Insertion(int[] input)
        {
            for (int i = 1; i < input.Length; i++)
            {
                var j = i;

                while (j > 0 && input[j] < input[j - 1])
                {
                    Swap(input, j, j - 1);
                    j--;
                }
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
