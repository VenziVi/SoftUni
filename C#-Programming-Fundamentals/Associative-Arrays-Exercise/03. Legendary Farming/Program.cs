using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            Dictionary<string, int> junkMaterials = new Dictionary<string, int>();

            keyMaterials.Add("shards", 0);
            keyMaterials.Add("fragments", 0);
            keyMaterials.Add("motes", 0);

            bool isNeedToBreak = false;

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string material = input[i + 1].ToLower();

                    if (material == "shards" || material == "fragments" || material == "motes")
                    {
                        keyMaterials[material] += quantity;

                        if (keyMaterials[material] >= 250)
                        {
                            keyMaterials[material] -= 250;

                            if (material == "shards")
                            {
                                Console.WriteLine("Shadowmourne obtained!");
                            }
                            else if (material == "fragments")
                            {
                                Console.WriteLine("Valanyr obtained!");
                            }
                            else if (material == "motes")
                            {
                                Console.WriteLine("Dragonwrath obtained!");
                            }

                            isNeedToBreak = true;
                            break;
                        }
                    }
                    else
                    {
                        if (!junkMaterials.ContainsKey(material))
                        {
                            junkMaterials.Add(material, 0);
                        }

                        junkMaterials[material] += quantity;
                    }
                }

                if (isNeedToBreak)
                {
                    break;
                }
            }

            Dictionary<string, int> sortedKeyMaterials = keyMaterials
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
           
            foreach (var line in sortedKeyMaterials)
            {
                Console.WriteLine($"{line.Key}: {line.Value}");
            }

            foreach (var line in junkMaterials.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{line.Key}: {line.Value}");
            }
        }
    }
}
