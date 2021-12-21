using System;
using System.Collections.Generic;

namespace _02.PermutationsWithRepetition
{
    internal class Program
    {
        private static string[] elements;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(' ');
            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            Permute(index + 1);

            var swappedElements = new  HashSet<string> { elements[index] };

            for (int i = index + 1; i < elements.Length; i++)
            {
                if (!swappedElements.Contains(elements[i]))
                {
                    Swap(index, i);
                    Permute(index + 1);
                    Swap(index, i);
                    swappedElements.Add(elements[i]);
                }
            }
        }

        private static void Swap(int index, int i)
        {
            var temp = elements[index];
            elements[index] = elements[i];
            elements[i] = temp;
        }
    }
}
