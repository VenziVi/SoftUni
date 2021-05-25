using System;

namespace _02._Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int digitSum = 0;

            while (number > 0)
            {
                int digit = number % 10;
                number = number / 10;
                digitSum += digit;

            }
            Console.WriteLine(digitSum);
        }
    }
}
