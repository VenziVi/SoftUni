using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            //string text = Console.ReadLine();
            //string[] words = text
            //    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            //Func<string, bool> isUpper = text => char.IsUpper(text[0]);

            //words = words.Where(isUpper).ToArray();


            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(w => w[0] == w.ToUpper()[0])
                .ToArray();

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }


        }
    }
}
