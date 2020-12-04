using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Moving_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command.ToLower() != "end")
            {
                string[] cmd = command.Split();
                string manipulation = cmd[0];
                int index = int.Parse(cmd[1]);
                int value = int.Parse(cmd[2]);

                if (manipulation == "Shoot")
                {
                    if (index >= 0 && index < targets.Count)
                    {
                        targets[index] -= value;

                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                    }
                }

                if (manipulation == "Add")
                {
                    if (index >= 0 && index < targets.Count)
                    {
                        targets.Insert(index, value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                }

                if (manipulation == "Strike")
                {
                    if ((index - value) >= 0 && (index + value) <= targets.Count)
                    {
                        targets.RemoveRange((index - value), (1 + (value * 2)));
                    }
                    else
                    {
                        Console.WriteLine("Strike missed!");
                    }
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join('|', targets));
        }
    }
}
