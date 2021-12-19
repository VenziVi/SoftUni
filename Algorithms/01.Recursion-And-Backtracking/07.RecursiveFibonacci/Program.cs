using System;

namespace _07.RecursiveFibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(CalcFib(n));
        }

        static long CalcFib(int number)
        {
            if (number <= 1)
            {
                return 1;
            }

            return CalcFib(number - 1) + CalcFib(number - 2);
        }
    }
}
