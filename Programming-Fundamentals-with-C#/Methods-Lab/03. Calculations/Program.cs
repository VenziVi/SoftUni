using System;

namespace _03._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string function = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            switch (function)
            {
                case "add":
                    add(a, b);
                    break;
                case "multiply":
                    multiply(a, b);
                    break;
                case "subtract":
                    subtract(a, b);
                    break;
                case "divide":
                    divide(a, b);
                    break;
            }
        }

        private static void divide(int a, int b)
        {
            Console.WriteLine(a / b);
        }

        private static void subtract(int a, int b)
        {
            Console.WriteLine(a - b);
        }

        private static void multiply(int a, int b)
        {
            Console.WriteLine(a * b);
        }

        private static void add(int a, int b)
        {
            Console.WriteLine(a + b);
        }
    }
}
