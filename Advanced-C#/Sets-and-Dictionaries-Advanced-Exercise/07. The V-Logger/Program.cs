using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> app 
                = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] splited = input.Split();
                string vloggerName = splited[0];
                string command = splited[1];

                if (command == "joined")
                {
                    if (!app.ContainsKey(vloggerName))
                    {
                        app.Add(vloggerName, new Dictionary<string, SortedSet<string>>());
                        app[vloggerName].Add("followings", new SortedSet<string>());
                        app[vloggerName].Add("followers", new SortedSet<string>());
                    }
                }
                else if (command == "followed")
                {
                    string secondName = splited[2];

                    if (app.ContainsKey(vloggerName) && app.ContainsKey(secondName) && vloggerName != secondName)
                    {
                        app[vloggerName]["followings"].Add(secondName);
                        app[secondName]["followers"].Add(vloggerName);
                    }
                }

                input = Console.ReadLine();
            }

            Dictionary<string, Dictionary<string, SortedSet<string>>> sortedData =
                app.OrderByDescending(k => k.Value["followers"].Count).ThenBy(k => k.Value["followings"].Count)
                .ToDictionary(k => k.Key, k => k.Value);

            int count = 0;

            Console.WriteLine($"The V-Logger has a total of {sortedData.Values.Count} vloggers in its logs.");

            foreach (KeyValuePair<string, Dictionary<string, SortedSet<string>>> item in sortedData)
            {
                Console.WriteLine($"{++count}. {item.Key} : {item.Value["followers"].Count} followers, {item.Value["followings"].Count} following");

                if (count == 1)
                {
                    foreach (var name in item.Value["followers"])
                    {
                        Console.WriteLine($"*  {name}");
                    }
                }
            }
        }
    }
}
