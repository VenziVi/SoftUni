using System;
using System.Text.RegularExpressions;

namespace _02._Ad_Astra
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(\||#)([A-Z a-z]+)\1([0-3][1-9]\/[0-1][0-9]\/[2][0-1])\1([0-9]{1,5})\1";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);
            int calories = 0;

            foreach (Match match in matches)
            {
                int currentCalories = int.Parse(match.Groups[4].Value);
                calories += currentCalories;
            }

            int days = calories / 2000;

            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach (Match item in matches)
            {
                Console.WriteLine($"Item: {item.Groups[2].Value}, Best before: {item.Groups[3].Value}, Nutrition: {item.Groups[4].Value}");
            }
        }
    }
}
