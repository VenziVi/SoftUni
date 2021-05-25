﻿using System;

namespace _1._The_Hunting_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int players = int.Parse(Console.ReadLine());
            double energy = double.Parse(Console.ReadLine());
            double waterPerDay = double.Parse(Console.ReadLine());
            double foodPerDay = double.Parse(Console.ReadLine());
            double totalWater = days * players * waterPerDay;
            double totalFood = days * players * foodPerDay;
            int dayCounter = 0;

            while (true)
            {
                dayCounter++;

                if (dayCounter > days)
                {
                    break;
                }

                double energyLoss = double.Parse(Console.ReadLine());
                energy -= energyLoss;

                if (energy <= 0)
                {
                    break;
                }

                if (dayCounter % 2 == 0)
                {
                    energy *= 1.05;
                    totalWater *= 0.7;
                }

                if (dayCounter % 3 == 0)
                {
                    energy *= 1.1;
                    totalFood -= totalFood / players;
                }
            }

            if (energy > 0)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {energy:f2} energy!");
            }
            else
            {
                Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water.");
            }
        }
    }
}
