using System;

namespace _05._Print_Part_Of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int charStart = int.Parse(Console.ReadLine());
            int charEnd = int.Parse(Console.ReadLine());

            for (int i = charStart; i <= charEnd; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}
