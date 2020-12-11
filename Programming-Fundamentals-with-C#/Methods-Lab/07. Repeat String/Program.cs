using System;

namespace _07._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            string result = StringRepeat(text, n);
            Console.WriteLine(result);
        }

        static string StringRepeat(string text, int n)
        {
            string result = "";
            for (int i = 0; i < n; i++)
            {
                result += text;
            }
            return result;
        }
    }
}
