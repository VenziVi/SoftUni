using System;
using System.Collections.Generic;

namespace _04._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> continents =
                new Dictionary<string, Dictionary<string, List<string>>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!continents.ContainsKey(continent))
                {
                    continents.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!continents[continent].ContainsKey(country))
                {
                    continents[continent].Add(country, new List<string>());
                }

                continents[continent][country].Add(city);
            }

            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var city in continent.Value)
                {
                    Console.Write($"{city.Key} -> ");

                    for (int i = 0; i < city.Value.Count; i++)
                    {
                        if (i == city.Value.Count - 1)
                        {
                            Console.Write($"{city.Value[i]}");
                        }
                        else
                        {
                            Console.Write($"{city.Value[i]}, ");
                        }
                    }

                    Console.WriteLine();
                }

            }
        }
    }
}
