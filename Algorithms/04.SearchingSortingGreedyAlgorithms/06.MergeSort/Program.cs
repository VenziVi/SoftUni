using System;
using System.Linq;

namespace _06.MergeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var result = Merge(input);
            Console.WriteLine(string.Join(" ", result));
        }

        private static int[] Merge(int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }

            var left = array.Take(array.Length / 2).ToArray();
            var right = array.Skip(array.Length / 2).ToArray();

            return MergeArray(Merge(left), Merge(right));
        }

        private static int[] MergeArray(int[] left, int[] right)
        {
            var merged = new int[left.Length + right.Length];

            var mergeIndex = 0;
            var leftIndex = 0;
            var rightIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] < right[rightIndex])
                {
                    merged[mergeIndex++] = left[leftIndex++];
                }
                else
                {
                    merged[mergeIndex++] = right[rightIndex++];
                }
            }

            for (int i = leftIndex; i < left.Length; i++)
            {
                merged[mergeIndex++] = left[i];
            }

            for (int i = rightIndex; i < right.Length; i++)
            {
                merged[mergeIndex++] = right[i];
            }

            return merged;
        }
    }
}
