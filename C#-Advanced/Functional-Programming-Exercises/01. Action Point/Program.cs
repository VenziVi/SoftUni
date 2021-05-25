using System;

namespace _01._Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();

            Action<string[]> printName = name => Console.WriteLine(string.Join(Environment.NewLine, name));

            printName(names);
        }
    }
}
