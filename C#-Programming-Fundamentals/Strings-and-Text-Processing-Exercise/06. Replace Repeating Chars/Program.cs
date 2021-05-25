using System;

namespace _06._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int letter = 0;
            char[] text = input.ToCharArray();
            string result = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                int ascii = text[i];
                
                if (ascii != letter)
                {
                    letter = ascii;
                    result += text[i];
                }
            }

            Console.WriteLine(result);
        }
    }
}
