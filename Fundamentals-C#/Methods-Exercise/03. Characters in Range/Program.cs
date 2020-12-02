using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char letter1 = char.Parse(Console.ReadLine());
            char letter2 = char.Parse(Console.ReadLine());

            CharactersBetween(letter1, letter2);
        }

        private static void CharactersBetween(char letter1, char letter2)
        {
            if ((int)(letter1) <= (int)(letter2))
            {
                for (int i = letter1 + 1; i < letter2; i++)
                {
                    char symbol = (char)(i);
                    Console.Write($"{symbol} ");
                }
            }
            else
            {
                for (int i = letter2 + 1; i < letter1; i++)
                {
                    char symbol = (char)(i);
                    Console.Write($"{symbol} ");
                }
            }
         
        }
    }
}
