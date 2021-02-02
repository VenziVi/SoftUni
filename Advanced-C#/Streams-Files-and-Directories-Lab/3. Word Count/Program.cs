using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            var matces = new Dictionary<string, int>();
            var reader = new StreamReader("../../../words.txt");
            using (reader)
            {
                string[] words = reader.ReadToEnd().Split();

                for (int i = 0; i < words.Length; i++)
                {
                    string currWord = words[i].ToLower();

                    var textReader = new StreamReader("../../../input.txt");
                    using (textReader)
                    {
                        var text = textReader.ReadLine();

                        while (text != null)
                        {
                            if (text.ToLower().Contains(currWord))
                            {
                                if (!matces.ContainsKey(currWord))
                                {
                                    matces.Add(currWord, 0);
                                }
                                matces[currWord]++;
                            }

                            text = textReader.ReadLine();
                        }
                    }
                }
            }

            using (var writer = new StreamWriter("../../../output.txt"))
            {
                foreach (var word in matces.OrderByDescending(v => v.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            } 
        }
    }
}
