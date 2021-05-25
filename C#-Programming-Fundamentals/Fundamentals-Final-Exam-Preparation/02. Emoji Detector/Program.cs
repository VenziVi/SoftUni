using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberPattern = @"\d";
            string emojiPattern = @"(:{2}|\*{2})([A-Z][a-z]{2,})+\1";
            Regex numReg = new Regex(numberPattern);
            long coolTreshold = 1;

            string text = Console.ReadLine();

            numReg.Matches(text)
                .Select(x => x.Value)
                .Select(int.Parse)
                .ToList()
                .ForEach(x => coolTreshold *= x);

            Regex emojiReg = new Regex(emojiPattern);

            string[] emojis = emojiReg.Matches(text).Select(x => x.Value).ToArray();

            int emojiCount = emojis.Length;
            List<string> coolEmoji = new List<string>();

            for (int i = 0; i < emojis.Length; i++)
            {
                string emoji = emojis[i];
                int emojiCharSum = 0;

                for (int j = 2; j < emoji.Length - 2; j++)
                {
                    emojiCharSum += emoji[j];

                    if (emojiCharSum > coolTreshold)
                    {
                        if (!coolEmoji.Contains(emoji))
                        {
                            coolEmoji.Add(emoji);
                        }
                        
                    }
                }

            }

            Console.WriteLine($"Cool threshold: {coolTreshold}");
            Console.WriteLine($"{emojiCount} emojis found in the text. The cool ones are:");
            Console.WriteLine(string.Join(Environment.NewLine, coolEmoji));
        }
    }
}
