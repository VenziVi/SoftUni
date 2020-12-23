using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Sugar_Cubes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> cubs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string line = Console.ReadLine();

            while (line != "Mort")
            {
                string[] command = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string cmd = command[0];
                int value = int.Parse(command[1]);

                if (cmd == "Add")
                {
                    cubs.Add(value);
                }
                else if (cmd == "Remove")
                {
                    for (int i = 0; i < cubs.Count; i++)
                    {
                        if (cubs[i] == value)
                        {
                            cubs.Remove(cubs[i]);
                            break;
                        }
                    }
                }
                else if (cmd == "Replace")
                {
                    int replacment = int.Parse(command[2]);

                    for (int i = 0; i < cubs.Count; i++)
                    {
                        if (cubs[i] == value)
                        {
                            int replacementIndex = cubs.IndexOf(cubs[i]);
                            cubs[replacementIndex] = replacment;
                            break;
                        }
                    }
                }
                else if (cmd == "Collapse")
                {
                    for (int i = 0; i < cubs.Count; i++)
                    {
                        if (cubs[i] < value)
                        {
                            cubs.Remove(cubs[i]);
                            i = i - 1;
                        }
                    }
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ",cubs));
        }
    }
}
