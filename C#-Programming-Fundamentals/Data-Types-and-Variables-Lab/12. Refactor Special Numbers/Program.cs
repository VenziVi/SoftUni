using System;

namespace _12._Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());

            for (int currentNum = 1; currentNum <= numbers; currentNum++)
            {
                int sum = 0;
                int num = currentNum;
                while (num > 0)
                {
                    int digit = num % 10;
                    num = num / 10;
                    sum += digit;
                }
                bool isSpecial = (sum == 5) || (sum == 7) || (sum == 11); 

                Console.WriteLine($"{currentNum} -> {isSpecial}");
            }

        }
    }
}
