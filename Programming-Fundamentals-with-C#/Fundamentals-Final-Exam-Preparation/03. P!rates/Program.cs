using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> cities = new Dictionary<string, List<int>>();
            string cityInput = Console.ReadLine();

            while (cityInput != "Sail")
            {
                string[] input = cityInput.Split("||");
                string city = input[0];
                int population = int.Parse(input[1]);
                int gold = int.Parse(input[2]);

                if (!cities.ContainsKey(city))
                {
                    cities.Add(city, new List<int> { population, gold });
                }
                else
                {
                    cities[city][0] += population;
                    cities[city][1] += gold;
                }

                cityInput = Console.ReadLine();
            }

            string eventsCommand = Console.ReadLine();

            while (eventsCommand != "End")
            {
                string[] input = eventsCommand.Split("=>");
                string typeOfCommand = input[0];

                if (typeOfCommand == "Plunder")
                {
                    string town = input[1];
                    int killedPeople = int.Parse(input[2]);
                    int stolenGold = int.Parse(input[3]);

                    Console.WriteLine($"{town} plundered! {stolenGold} gold stolen, {killedPeople} citizens killed.");

                    cities[town][0] -= killedPeople;
                    cities[town][1] -= stolenGold;

                    if (cities[town][0] == 0 || cities[town][1] == 0)
                    {
                        cities.Remove(town);
                        Console.WriteLine($"{town} has been wiped off the map!");
                    }
                }
                else if (typeOfCommand == "Prosper")
                {
                    string town = input[1];
                    int addedGold = int.Parse(input[2]);

                    if (addedGold >= 0)
                    {
                        cities[town][1] += addedGold;
                        int totalGold = cities[town][1];
                        Console.WriteLine($"{addedGold} gold added to the city treasury. {town} now has {totalGold} gold.");
                    }
                    else
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                }
                eventsCommand = Console.ReadLine();
            }

            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");

                foreach (var city in cities.OrderByDescending(x =>x.Value[1])
                    .ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{city.Key} -> Population: {city.Value[0]} citizens, Gold: {city.Value[1]} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
