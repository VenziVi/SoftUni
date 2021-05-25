using System;

namespace _05._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int num = 1; num <= n ; num++)
            {
                int sumN = 0;
                int number = num;
                while (number > 0)
                {
                    int digit = number % 10;
                    number = number / 10;
                    sumN += digit;
                }
                bool isSpecial = (sumN == 5) ||
                                 (sumN == 7) ||
                                 (sumN == 11);
                Console.WriteLine($"{num} -> {isSpecial}");
                
            }
        }
    }
}
