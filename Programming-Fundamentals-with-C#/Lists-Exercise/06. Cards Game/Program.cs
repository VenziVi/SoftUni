using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayer = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> secondPlayer = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (firstPlayer.Count != 0 && secondPlayer.Count != 0)
            {
                int firstPlayerCard = firstPlayer[0];
                int seconadPlayerCard = secondPlayer[0];

                if (firstPlayerCard > seconadPlayerCard)
                {
                    firstPlayer.Add(seconadPlayerCard);
                    firstPlayer.Add(firstPlayerCard);
                }
                else if (seconadPlayerCard > firstPlayerCard)
                {
                    secondPlayer.Add(firstPlayerCard);
                    secondPlayer.Add(seconadPlayerCard);
                }

                firstPlayer.RemoveAt(0);
                secondPlayer.RemoveAt(0);

            }
            if (firstPlayer.Count == 0)
            {
                Console.WriteLine($"Second player wins! Sum: {secondPlayer.Sum()}");
            }
            else
            {
                Console.WriteLine($"First player wins! Sum: {firstPlayer.Sum()}");
            }
        }

    }
}
