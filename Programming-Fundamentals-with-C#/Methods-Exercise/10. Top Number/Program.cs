using System;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            DevisibleSum(num);

        }

        private static void DevisibleSum(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                string currentNumber = i.ToString();
                bool isOddDigit = false;
                int sumOfDigits = 0;

                foreach (var curr in currentNumber)
                {
                    int parseNumb = (int)curr;

                    if (parseNumb % 2 == 1)
                    {
                        isOddDigit = true;
                    }

                    sumOfDigits += parseNumb;

                }
                if (sumOfDigits % 8 == 0 && isOddDigit)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
