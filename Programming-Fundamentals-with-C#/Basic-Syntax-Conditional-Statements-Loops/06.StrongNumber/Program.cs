using System;

namespace StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int currentNumber = number;
            int factorialSum = 0;

            while (number != 0)
            {
                int lastDigit = number % 10;
                number /= 10;

                int factorial = 1;

                for (int i = 1; i <= lastDigit; i++)
                {
                    factorial *= i;
                }

                factorialSum += factorial;
            }

            string result = string.Empty;

            if (factorialSum == currentNumber)
            {
                result = "yes";
            }
            else
            {
                result = "no";
            }
            Console.WriteLine(result);
        }
    }
}
