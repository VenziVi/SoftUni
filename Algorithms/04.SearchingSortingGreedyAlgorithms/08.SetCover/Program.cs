using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.SetCover
{
    internal class Program
    {
        static void Main()
        {
            var univers = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToHashSet();

            var n = int.Parse(Console.ReadLine());

            var sets = new List<int[]>();

            for (int i = 0; i < n; i++)
            {
                var set = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                sets.Add(set);
            }

            var selectedSets = new List<int[]>();

            while (univers.Count > 0)
            {
                var set = sets
                    .OrderByDescending(s => s.Count(e => univers.Contains(e)))
                    .FirstOrDefault();

                selectedSets.Add(set);

                sets.Remove(set);

                foreach (var el in set)
                {
                    univers.Remove(el);
                }
            }

            Console.WriteLine($"Sets to take ({selectedSets.Count}):");

            foreach (var set in selectedSets)
            {
                Console.WriteLine(string.Join(", ", set));   
            }
        }
    }
}
