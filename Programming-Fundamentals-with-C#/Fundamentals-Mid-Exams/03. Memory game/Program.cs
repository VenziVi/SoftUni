using System;
using System.Collections.Generic;
using System.Linq;


namespace _3._Memory_game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();
            int moves = 0;

            while (command != "end")
            {
                string[] cmd = command.Split();
                int firstIndex = int.Parse(cmd[0]);
                int secondIndex = int.Parse(cmd[1]);
                moves++;


                if (firstIndex == secondIndex ||
                    firstIndex < 0 ||
                    firstIndex >= input.Count ||
                    secondIndex < 0 ||
                    secondIndex >= input.Count)
                {
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    var numOfMove = $"-{moves}a";
                    input.Insert(input.Count / 2, $"-{moves}a");
                    input.Insert(input.Count / 2, $"-{moves}a");
                }
                else
                {


                    if (input[firstIndex] == input[secondIndex])
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {input[firstIndex]}!");

                        if (firstIndex > secondIndex)
                        {
                            input.RemoveAt(firstIndex);
                            input.RemoveAt(secondIndex);
                        }
                        else
                        {
                            input.RemoveAt(secondIndex);
                            input.RemoveAt(firstIndex);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Try again!");
                    }

                    if (input.Count == 0)
                    {
                        Console.WriteLine($"You have won in {moves} turns!");
                        break;
                    }
                }

                command = Console.ReadLine();
            }

            if (input.Count > 1)
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ", input));
            }
        }
    }
}
