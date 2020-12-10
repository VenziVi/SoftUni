using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine().ToLower();

            while (command != "end")
            {
                string[] function = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (function[0].ToLower())
                {
                    case "add":
                        numbers.Add(int.Parse(function[1]));
                        break;
                    case "remove":
                        numbers.Remove(int.Parse(function[1]));
                        break;
                    case "removeat":
                        numbers.RemoveAt(int.Parse(function[1]));
                        break;
                    case "insert":
                        numbers.Insert(int.Parse(function[2]), int.Parse(function[1]));
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(' ', numbers));

        }
    }
}
