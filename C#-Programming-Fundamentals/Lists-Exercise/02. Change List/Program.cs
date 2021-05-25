using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string[] command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "end")
            {
                switch (command[0])
                {
                    case "Delete":
                        numbers.RemoveAll(n => n == int.Parse(command[1]));
                        break;
                    case "Insert":
                        numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
