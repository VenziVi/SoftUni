using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine().ToCharArray();
            Dictionary<char, int> chs = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!chs.ContainsKey(text[i]))
                {
                    chs.Add(text[i], 0);
                }

                chs[text[i]]++;
            }

            foreach (var ch in chs.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
            }
        }
    }
}
