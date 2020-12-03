using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();

            List<int> result = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                List<int> numbers = arr[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                for (int j = 0; j < numbers.Count; j++)
                {
                    result.Add(numbers[j]);
                }
            }
            Console.WriteLine(string.Join(' ', result));
            
        }
    }
}
