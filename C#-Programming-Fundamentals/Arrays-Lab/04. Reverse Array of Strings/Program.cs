using System;
using System.Linq;

namespace _04._Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split(" ").ToArray();
            string[] text = new string[line.Length];
            for (int i = 0; i < line.Length; i++)
            {
                text[i] = line[i];
            }
            for (int i = text.Length - 1; i >= 0; i--)
            {
                Console.Write($"{text[i]} ");
            }
        }
    }
}
