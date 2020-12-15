using System;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var word1 = input[0];
            var word2 = input[1];

            var longest = word1;
            var shorter = word2;

            if (word1.Length < word2.Length)
            {
                longest = word2;
                shorter = word1;
            }

            var total = Manipuliter(longest, shorter);
            Console.WriteLine(total);
        }

        public static int Manipuliter(string longest, string shorter)
        {
            var sum = 0;

            for (int i = 0; i < shorter.Length; i++)
            {
                var multiply = longest[i] * shorter[i];
                sum += multiply;
            }

            for (int i = shorter.Length; i < longest.Length; i++)
            {
                sum += longest[i];
            }

            return  sum;
        }
    }
}
