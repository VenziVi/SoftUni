using System;

namespace _01.PermutationsWithoutRepetition
{
    internal class Program
    {
        private static string[] input;
        static void Main(string[] args)
        {
            input = Console.ReadLine().Split(' ');
            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= input.Length)
            {
                Console.WriteLine(string.Join(" ", input));
                return;
            }

            Permute(index + 1);

            for (int i = index + 1; i < input.Length; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }

        }

        private static void Swap(int index, int i)
        {
            var temp = input[i];
            input[i] = input[index];
            input[index] = temp;
        }
    }
}
