using System;

namespace _03.VariationsWithoutRepetition
{
    internal class Program
    {
        private static string[] elements;
        private static string[] variations;
        private static bool[] used;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(' ');
            int k = int.Parse(Console.ReadLine());

            variations = new string[k];
            used = new bool[elements.Length];
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
                if (!used[i])
                {
                    used[i] = true;
                    variations[index] = elements[i];
                    Variation(index + 1);
                    used[i] = false;
                }
            }
        }
    }
}
