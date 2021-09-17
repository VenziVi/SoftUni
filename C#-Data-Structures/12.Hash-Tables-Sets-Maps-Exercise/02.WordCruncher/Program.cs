using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.WordCruncher
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ").ToList();
            var searchedtWord = Console.ReadLine();
            var results = new HashSet<string>();

            FindWords(input, searchedtWord, results);

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }

        private static void FindWords(List<string> input, string searchedtWord, HashSet<string> results, string createdWord = "")
        {
            var newWord = createdWord.Split().ToList();
            var currWord = string.Join("", newWord);

            if (currWord == searchedtWord)
            {
                results.Add(createdWord.TrimStart());
                return;
            }

            foreach (var syllable in input)
            {
                var concatWord = $"{currWord}{syllable}";

                if (searchedtWord.StartsWith(concatWord))
                {
                    var updatedInput = new List<string>(input);
                    updatedInput.Remove(syllable);

                    FindWords(updatedInput, searchedtWord, results, $"{createdWord} {syllable}");
                }
            }
        }
    }
}