using System;

namespace _04.VariationsWithRepetition
{
    internal class Program
    {
        private static string[] elements;
        private static string[] variations;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(' ');
            int k = int.Parse(Console.ReadLine());

            variations = new string[k];
            Variation(0);
        }

        private static void Variation(int index)
        {
            if (index >= variations.Length)
            {
                Console.WriteLine(String.Join(' ', variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                variations[index] = elements[i];
                Variation(index + 1);
            }
        }
    }
}
