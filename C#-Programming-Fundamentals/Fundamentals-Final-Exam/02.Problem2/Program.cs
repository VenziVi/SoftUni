using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\*|@)([A-Z][a-z]{2,})\1: \[([A-Za-z])\]\|\[([A-Za-z])\]\|\[([A-Za-z])\]\|$";
            Regex regex = new Regex(pattern);
            var nums = new List<int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);

                if (match.Success)
                {
                    string tag = match.Groups[2].Value;
                    int num1 = char.Parse(match.Groups[3].Value);
                    int num2 = char.Parse(match.Groups[4].Value);
                    int num3 = char.Parse(match.Groups[5].Value);

                    nums = new List<int> { num1, num2, num3 };
                    Console.WriteLine($"{tag}: {string.Join(" ", nums)}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
