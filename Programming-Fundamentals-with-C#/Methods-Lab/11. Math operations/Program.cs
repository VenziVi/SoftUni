using System;

namespace _11._Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            string function = Console.ReadLine();
            int b = int.Parse(Console.ReadLine());

            double result = Calculated(a, function, b);
            Console.WriteLine(result);
        }

        private static double Calculated(int a, string function, int b)
        {
            double result = 0.0;

            switch (function)
            {
                case "/":
                    result = a / b;
                    break;
                case "*":
                    result = a * b;
                    break;
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
            }
            return result;
        }
    }
}
