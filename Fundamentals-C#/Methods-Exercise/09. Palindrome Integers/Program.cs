using System;
using System.Linq;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string num = Console.ReadLine();
                if (num == "END")
                {
                    break;
                }

                Revers(num);
            }
        }

        private static void Revers(string num)
        {
            int oldNumb = int.Parse(num);
            int number = int.Parse(num);
            int reversed = 0;

            while (number >0)
            {
                int digit = number % 10;
                reversed = (reversed * 10) + digit;
                number /= 10;
            }

            if (oldNumb == reversed)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
