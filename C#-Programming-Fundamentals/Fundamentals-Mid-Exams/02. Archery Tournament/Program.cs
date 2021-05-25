using System;
using System.ComponentModel.Design;
using System.Linq;

namespace _2._Archery_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] field = Console.ReadLine()
                .Split("|")
                .Select(int.Parse)
                .ToArray();

            int points = 0;
            string command = Console.ReadLine();

            while (command != "Game over")
            {
                string[] cmdArgs = command.Split();
                string cmd = cmdArgs[0];

                if (cmd == "Shoot")
                {
                    string[] shootcommand = cmdArgs[1].Split("@");
                    string direction = shootcommand[0];
                    int index = int.Parse(shootcommand[1]);
                    int length = int.Parse(shootcommand[2]);

                    if (index >= 0 && index < field.Length)
                    {
                        if (direction == "Left")
                        {
                            length %= field.Length;
                            int offset = field.Length - length;
                            int targetIndex = (index + offset) % field.Length;

                            if (field[targetIndex] <= 5)
                            {
                                points += field[targetIndex];
                                field[targetIndex] = 0;
                            }
                            else
                            {
                                points += 5;
                                field[targetIndex] -= 5;
                            }
                        }
                        else if (direction == "Right")
                        {

                            int targetIndex = (index + length) % field.Length;

                            if (field[targetIndex] <= 5)
                            {
                                points += field[targetIndex];
                                field[targetIndex] = 0;
                            }
                            else
                            {
                                points += 5;
                                field[targetIndex] -= 5;
                            }
                            
                        }
                    }

                }

                else if (cmd == "Reverse")
                {
                    Array.Reverse(field);
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" - ", field));
            Console.WriteLine($"Iskren finished the archery tournament with {points} points!");
        }
    }
}
