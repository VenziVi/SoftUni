using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\=|\/)([A-Z][A-Za-z]{2,})(\1)";
            var destinations = new List<string>();
            int counter = 0;
            string text = Console.ReadLine();
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                string destination = match.Groups[2].Value;
                counter += destination.Length;
                destinations.Add(destination);
            }

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {counter}");
        }
    }
}
