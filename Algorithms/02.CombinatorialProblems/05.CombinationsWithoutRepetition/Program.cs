using System;

namespace _05.CombinationsWithoutRepetition
{
    internal class Program
    {
        private static string[] elements;
        private static string[] result;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(' ');
            var k = int.Parse(Console.ReadLine());

            result = new string[k];
            Combinations(0, 0);
        }

        private static void Combinations(int index, int startIndex)
        {
            if (index >= result.Length)
            {
                Console.WriteLine(String.Join(' ', result));
                return;
            }

            for (int i = startIndex; i < elements.Length; i++)
            {
                result[index] = elements[i];
                Combinations(index + 1, i + 1);
            }
        }
    }
}
