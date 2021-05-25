using System;
using System.Linq;

namespace _06._Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int oddSum = 0;
            int evenSum = 0;
            for (int i = 0; i < num.Length; i++)
            {
                int number = num[i];

                if (number % 2 == 0)
                {
                    evenSum += number;
                }
                else
                {
                    oddSum += number;
                }
            }
            int reault = evenSum - oddSum;
            Console.WriteLine(reault);
        }
    }
}
