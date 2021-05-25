using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int maxPasanger = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] cmdArg = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (cmdArg[0] == "Add")
                {
                    wagons.Add(int.Parse(cmdArg[1]));
                }
                else
                {
                    int passanger = int.Parse(cmdArg[0]);
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        int currentWagon = wagons[i];
                        bool isEnoughSpace = passanger + currentWagon <= maxPasanger;

                        if (isEnoughSpace)
                        {
                            wagons[i] += passanger;
                            break;
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(' ', wagons));
        }
    }
}
