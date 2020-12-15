using System;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string newText = string.Empty;

            char[] letters = input.ToCharArray();

            for (int i = 0; i < letters.Length; i++)
            {
                char newLetter = (char)(letters[i] + 3);
                
                newText += newLetter;
            }

            Console.WriteLine(newText);
        }
    }
}
