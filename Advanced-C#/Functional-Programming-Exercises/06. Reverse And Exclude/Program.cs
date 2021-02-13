using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int n = int.Parse(Console.ReadLine());

            input.Reverse();
            //input = input.Where(num => num % n != 0).ToList();
            Func<int, bool> predicate = num => num % n != 0;
            input = input.Where(predicate).ToList();
            Action<List<int>> print = n => Console.WriteLine(string.Join(" ", n));
            print(input);
        }
    }
}
