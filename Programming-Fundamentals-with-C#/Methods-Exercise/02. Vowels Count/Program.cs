using System;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();

            CountOfVowels(text);
        }

        private static void CountOfVowels(string text)
        {
            int vowelsCount = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 'a' ||
                    text[i] == 'e' ||
                    text[i] == 'i' ||
                    text[i] == 'o' ||
                    text[i] == 'u')
                {
                    vowelsCount++;
                }
            }
            Console.WriteLine(vowelsCount);

        }
    }
}
