using System;
using System.Collections.Generic;

namespace _2._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var counts = new Dictionary<string, int>();

            foreach (var word in words)
            {
                string wordinlower = word.ToLower();

                if (counts.ContainsKey(wordinlower))
                {
                    counts[wordinlower]++;
                }
                else
                {
                    counts.Add(wordinlower, 1);
                }
            }

            foreach (var word in counts)
            {
                if (word.Value % 2 == 1)
                {
                    Console.Write($"{word.Key} ");
                }
            }
        }
    }
}
