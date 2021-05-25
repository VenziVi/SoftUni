using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {

            string pattern = @"@([A-Za-z]+)[^@:!\->]*:(\d+)[^@:!\->]*!([A|D])![^@:!\->]*->(\d+)";
            Regex regex = new Regex(pattern);
            var n = int.Parse(Console.ReadLine());
            var planets = new Dictionary<string, List<string>>();
            planets.Add("Attacked", new List<string>());
            planets.Add("Destroyed", new List<string>());
               
            for (int i = 0; i < n; i++)
            {

                var input = Console.ReadLine();
                var key = 0;
                string decodedText = "";

                foreach (var ch in input.ToLower())
                {
                    if (ch == 's' || ch == 't' || ch == 'a' || ch == 'r')
                    {
                        key++;
                    }
                }

                foreach (var ch in input)
                {
                    char decodedChar = (char)(ch - key);
                    decodedText += decodedChar;
                }

                Match match = regex.Match(decodedText);

                if (match.Success)
                {
                    string planet = match.Groups[1].Value;
                    string attacType = match.Groups[3].Value;

                    if (attacType == "A")
                    {
                        planets["Attacked"].Add(planet);
                    }
                    else if (attacType == "D")
                    {       
                        planets["Destroyed"].Add(planet);
                    }
                }

            }

            foreach (var attack in planets)
            {

                if (attack.Key == "Attacked")
                {
                    Console.WriteLine($"Attacked planets: {attack.Value.Count}");
                }
                else if (attack.Key == "Destroyed")
                {
                    Console.WriteLine($"Destroyed planets: {attack.Value.Count}");
                }

                foreach (var planet in attack.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-> {planet}");
                }
            }

        }
    }
}
