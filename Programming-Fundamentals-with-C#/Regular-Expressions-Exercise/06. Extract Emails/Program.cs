using System;
using System.Text.RegularExpressions;

namespace _06._Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(^|(?<=\s))(([a-zA-Z0-9]+)([\.\-_]?)([A-Za-z0-9]+)(@)([a-zA-Z]+([\.\-_][A-Za-z]+)+))(\b|(?=\s))";
            Regex regex = new Regex(pattern);
            string[] input = Console.ReadLine().Split();


            for (int i = 0; i < input.Length; i++)
            {
                Match match = regex.Match(input[i]);

                if (match.Success)
                {
                    Console.WriteLine(match);
                }
            }
        }
    }
}
