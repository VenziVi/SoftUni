using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<int>> heros = new Dictionary<string, List<int>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string heroName = input[0];
                int HP = int.Parse(input[1]);
                int MP = int.Parse(input[2]);

                heros.Add(heroName, new List<int> {HP, MP });       
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] cmdArg = command.Split(" - ");
                string cmd = cmdArg[0];
                string name = cmdArg[1];

                if (cmd == "CastSpell")
                {
                    int mpNeeded = int.Parse(cmdArg[2]);
                    string spellName = cmdArg[3];

                    if (heros[name][1] >= mpNeeded)
                    {
                        heros[name][1] -= mpNeeded;
                        Console.WriteLine($"{name} has successfully cast {spellName} and now has {heros[name][1]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{name} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (cmd == "TakeDamage")
                {
                    int damage = int.Parse(cmdArg[2]);
                    string attacker = cmdArg[3];
                    heros[name][0] -= damage;

                    if (heros[name][0] > 0)
                    {
                        Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {heros[name][0]} HP left!");
                    }
                    else
                    {
                        heros.Remove(name);
                        Console.WriteLine($"{name} has been killed by {attacker}!");
                    }
                }
                else if (cmd == "Recharge")
                {
                    int amount = int.Parse(cmdArg[2]);
                    int mp = heros[name][1];
                    heros[name][1] += amount;

                    if (heros[name][1] > 200)
                    {
                        heros[name][1] = 200;
                        Console.WriteLine($"{name} recharged for {200 - mp} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{name} recharged for {amount} MP!");
                    }
                }
                else if (cmd == "Heal")
                {
                    int amount = int.Parse(cmdArg[2]);
                    int hp = heros[name][0];
                    heros[name][0] += amount;

                    if (heros[name][0] > 100)
                    {
                        heros[name][0] = 100;
                        Console.WriteLine($"{name} healed for {100 - hp} HP!");
                    }
                    else
                    {
                        Console.WriteLine($"{name} healed for {amount} HP!");
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var hero in heros.OrderByDescending(x => x.Value[0])
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{hero.Key}");
                Console.WriteLine($"HP: {hero.Value[0]}");
                Console.WriteLine($"MP: {hero.Value[1]}");
            }
        }
    }
}
