using System;
using System.Linq;

namespace _03._Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] neighborhood = Console.ReadLine()
                .Split('@')
                .Select(int.Parse)
                .ToArray();
            string line = Console.ReadLine();
            int LastPosition = 0;

            while (line != "Love!")
            {
                string[] command = line.Split();
                string cmdArg = command[0];
                int index = int.Parse(command[1]);
                index = index + LastPosition;               

                if (index < neighborhood.Length && index >= 0 )
                {
                    if (neighborhood[index] == 0)
                    {
                        Console.WriteLine($"Place {index} already had Valentine's day.");
                        LastPosition = index;
                    }
                    else if (neighborhood[index] > 0)
                    {
                        neighborhood[index] -= 2;
                        LastPosition = index;
                        if (neighborhood[index] == 0)
                        {
                            Console.WriteLine($"Place {LastPosition} has Valentine's day.");
                        }
                    }
                    
                }
                if (index >= neighborhood.Length)
                {
                    index = 0;
                    if (neighborhood[index] == 0)
                    {
                        Console.WriteLine($"Place {index} already had Valentine's day.");
                        LastPosition = index;
                    }
                    else if (neighborhood[index] > 0)
                    {
                        neighborhood[index] -= 2;
                        LastPosition = index;
                        if (neighborhood[index] == 0)
                        {
                            Console.WriteLine($"Place {LastPosition} has Valentine's day.");
                        }
                    }
                }              
                line = Console.ReadLine();
            }

            bool isSucsses = true;
            int count = 0;
            for (int i = 0; i < neighborhood.Length; i++)
            {
                if (neighborhood[i] > 0)
                {
                    count++;
                    isSucsses = false;
                }
            }
            if (isSucsses)
            {
                Console.WriteLine($"Cupid's last position was {LastPosition}.");
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid's last position was {LastPosition}.");
                Console.WriteLine($"Cupid has failed {count} places.");
            }
        }
    }
}
