using System;

namespace _1._Counter_Strike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int countOfWins = 0;

            string command = Console.ReadLine();

            while (command != "End of battle")
            {
                int distance = int.Parse(command);

                if (energy < distance)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {countOfWins} won battles and {energy} energy");
                    return;
                }

                energy -= distance;
                countOfWins++;

                if (countOfWins % 3 == 0)
                {
                    energy += countOfWins;
                }

                command = Console.ReadLine();

            }
            Console.WriteLine($"Won battles: {countOfWins}. Energy left: {energy}");
        }
    }
}
