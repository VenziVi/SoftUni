using System;

namespace _10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {

            int input = int.Parse(Console.ReadLine());

            int evenSum = GetSumOfEvenDigits(input);
            int sumOdd = GetSumOfOddDigits(input);
            int result = GetMultipleOfEvenAndOdds(evenSum, sumOdd);
            Console.WriteLine(result);
        }

        private static int GetMultipleOfEvenAndOdds(int evenSum, int sumOdd)
        {
            int result = evenSum * sumOdd;
            return result;
        }

        private static int GetSumOfOddDigits(int input)
        {
            int num = Math.Abs(input);
            int sum = 0;
            while (num > 0)
            {
                int lastNum = num % 10;
                num = num / 10;
                if (lastNum % 2 == 1)
                {
                    sum += lastNum;
                }
            }
            return sum;
        }

        private static int GetSumOfEvenDigits(int input)
        {
            int num = Math.Abs(input);
            int sum = 0;
            while (num >0)
            {
                int lastNum = num % 10;
                num = num / 10;
                if (lastNum % 2 == 0)
                {
                    sum += lastNum;
                }
            }
            return sum;
        }
    }
}
