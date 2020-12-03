using System;

namespace _06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            MidlleCharacter(text);
        }

        private static void MidlleCharacter(string text)
        {
            if (text.Length % 2 == 0)
            {
                Console.WriteLine(text.Substring((text.Length / 2) - 1, 2));
            }
            else
            {
                Console.WriteLine(text.Substring((text.Length / 2), 1));
            }
        }
    }
}
