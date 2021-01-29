using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();
            string input = Console.ReadLine();
            int counter = 0;

            while (input != "PARTY")
            {
                if (input.Length == 8)
                {
                    guests.Add(input);
                    counter++;
                }

                input = Console.ReadLine();
            }

            while (input != "END")
            {
                if (guests.Contains(input))
                {
                    guests.Remove(input);
                    counter--;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(counter);

            foreach (var number in guests)
            {
                char[] output = number.ToCharArray();
                if (char.IsDigit(output[0]))
                {
                    Console.WriteLine(number);
                }
            }
            foreach (var number in guests)
            {
                char[] output = number.ToCharArray();
                if (char.IsLetter(output[0]))
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}
