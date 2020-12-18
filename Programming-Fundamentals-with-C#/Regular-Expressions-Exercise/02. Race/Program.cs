using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] listOfPeoples = Console.ReadLine().Split(", ");
            Dictionary<string, int> dictionaryOfNames = new Dictionary<string, int>();

            foreach (var name in listOfPeoples)
            {
                dictionaryOfNames.Add(name, 0);
            }

            string namePattern = @"[\W\d]";
            string numberPattern = @"[\D]";

            string input = Console.ReadLine();

            while (input != "end of race")
            {
                string name = Regex.Replace(input, namePattern, "");
                string distance = Regex.Replace(input, numberPattern, "");
                int sum = 0;

                foreach (var digit in distance)
                {
                    int currDigit = int.Parse(digit.ToString());
                    sum += currDigit;
                }

                if (dictionaryOfNames.ContainsKey(name))
                {
                    dictionaryOfNames[name] += sum;
                }

                input = Console.ReadLine();
            }
            int count = 1;
            foreach (var kvp in dictionaryOfNames.OrderByDescending(x => x.Value))
            {
                string text = count == 1 ? "st" : count == 2 ? "nd" : "rd";

                Console.WriteLine($"{count++}{text} place: {kvp.Key}");

                if (count > 3)
                {
                    break;
                }
            }
            
        }
    }
}
