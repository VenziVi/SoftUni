using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            var mirrorWords = new List<string>();
            string pattern = @"(#|@)([A-Za-z]{3,})(\1\1)([A-Za-z]{3,})(\1)";
            string text = Console.ReadLine();
            Regex regex = new Regex(pattern);
            MatchCollection words = regex.Matches(text);

            foreach (Match word in words)
            {
                string firstWord = word.Groups[2].Value;
                string secondWord = word.Groups[4].Value;
                string reversedWord = string.Empty;

                for (int i = secondWord.Length - 1; i >= 0; i--)
                {
                    reversedWord += secondWord[i];
                }

                if (firstWord == reversedWord)
                {
                    string mirror = $"{firstWord} <=> {secondWord}";
                    mirrorWords.Add(mirror);
                }
            }

            if (words.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }
            else if (words.Count > 0)
            {
                Console.WriteLine($"{words.Count} word pairs found!");

                if (mirrorWords.Count == 0)
                {
                    Console.WriteLine("No mirror words!");
                }
                else if (mirrorWords.Count > 0)
                {
                    Console.WriteLine("The mirror words are:");
                    Console.WriteLine(string.Join(", ", mirrorWords));
                }
            }
        }
    }
}
