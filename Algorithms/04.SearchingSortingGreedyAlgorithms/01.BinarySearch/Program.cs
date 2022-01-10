using System;
using System.Linq;
using System.Threading;

namespace _01.BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var searched = int.Parse(Console.ReadLine());

            Console.WriteLine(Binary(input, searched));
        }

        private static int Binary(int[] input, int searched)
        {
            var first = 0;
            var last = input.Length - 1;

            while (first <= last )
            {
                var midd = (first + last) / 2;

                if (input[midd] == searched)
                {
                    return midd;
                }

                if (searched > input[midd])
                {
                    first = midd + 1;
                }
                else
                {
                    last = midd - 1;
                }
            }

            return -1;
        }
    }
}
