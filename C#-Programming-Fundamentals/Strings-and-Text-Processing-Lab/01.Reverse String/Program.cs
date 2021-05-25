using System;

namespace _01._ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            while (word != "end")
            {
                string revers = string.Empty;

                for (int i = word.Length - 1; i >= 0; i--)
                {
                    revers += word[i];
                }

                Console.WriteLine($"{word} = {revers}");

                word = Console.ReadLine();
            }
        }
    }
}
