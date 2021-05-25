using System;
using System.Linq;

namespace _2._Mu_Online
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] doungens = Console.ReadLine().Split('|');
            int health = 100;
            int bitcoins = 0;

            for (int i = 0; i < doungens.Length; i++)
            {
                int currentBitcoint = 0;
                string[] room = doungens[i].Split();
                string cmd = room[0];
                int value = int.Parse(room[1]);

                if (cmd == "potion")
                {
                    int teikenHealth = health;
                    health += value;
                    
                    if (health > 100)
                    {
                        health = 100;
                        int healsWith = 100 - teikenHealth;
                        Console.WriteLine($"You healed for {healsWith} hp.");
                    }
                    else
                    {
                        Console.WriteLine($"You healed for {value} hp.");
                    }
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (cmd == "chest")
                {
                    bitcoins += value;
                    currentBitcoint += value;
                    Console.WriteLine($"You found {currentBitcoint} bitcoins.");
                }
                else
                {
                    health -= value;
                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {cmd}.");
                        
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {cmd}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        return;

                    }
                }
            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");

        }
    }
}
