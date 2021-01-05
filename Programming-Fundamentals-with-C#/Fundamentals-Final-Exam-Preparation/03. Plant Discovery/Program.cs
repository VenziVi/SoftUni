using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Plant_Discovery
{
    class Program
    {

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var plants = new Dictionary<string, List<double>>();
            

            for (int i = 0; i < n; i++)
            {
                string[] plantInfo = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string plantName = plantInfo[0];
                double rarity = double.Parse(plantInfo[1]);
                if (!plants.ContainsKey(plantName))
                {
                    plants.Add(plantName, new List<double> { rarity });
                }
                else
                {
                    plants[plantName][0] = rarity;
                }
            }

            string command = Console.ReadLine();

            while (command != "Exhibition")
            {
                string[] input1 = command.Split(": ",StringSplitOptions.RemoveEmptyEntries);
                string cmd = input1[0];
                string[] input = input1[1].Split(" - ",StringSplitOptions.RemoveEmptyEntries);
                string plantName = input[0];


                if (cmd == "Rate")
                {
                    if (plants.ContainsKey(plantName))
                    {
                        double rate = double.Parse(input[1]);
                        plants[plantName].Add(rate);
                    }
                    else
                    {
                        Console.WriteLine($"error");
                    }                  
                }
                else if (cmd == "Update")
                {
                    double rarity = double.Parse(input[1]);
                    if (plants.ContainsKey(plantName))
                    {
                        plants[plantName][0] = rarity;
                    }
                    else
                    {
                        Console.WriteLine($"error");
                    }
                }
                else if (cmd == "Reset")
                {
                    if (plants[plantName].Count > 0)
                    {
                        int endIndex = plants[plantName].Count - 1;

                        if (plants.ContainsKey(plantName))
                        {
                            plants[plantName].RemoveRange(1, endIndex);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"error");
                    }
                }
                else
                {
                    Console.WriteLine($"error");
                }

                command = Console.ReadLine();
            }

            
            foreach (var item in plants)
            {
                double average = 0;
                if (item.Value.Count > 1)
                {
                    double sum = 0;
                    for (int i = 1; i < item.Value.Count; i++)
                    {                        
                        sum += item.Value[i];                       
                    }
                    average = sum / (item.Value.Count - 1);
                }
                else 
                {
                    average = 0;
                }
                item.Value.Insert(1, average);
            }

            Console.WriteLine("Plants for the exhibition:");

            foreach (var plant in plants.OrderByDescending(x => x.Value[0])
                .ThenByDescending(x => x.Value[1]))
            {
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value[0]}; Rating: {plant.Value[1]:f2}");
            }

        }
    }

}
