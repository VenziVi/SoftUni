using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> numbers = new Stack<string>(input.Reverse());

            while (numbers.Count > 1)
            {
                var firstNum = int.Parse(numbers.Pop());
                var sign = numbers.Pop();
                var SecondNum = int.Parse(numbers.Pop());

                if (sign == "-")
                {
                    numbers.Push((firstNum - SecondNum).ToString());
                }
                else if (sign == "+")
                {
                    numbers.Push((firstNum + SecondNum).ToString());
                }
            }

            Console.WriteLine(numbers.Pop());
        }
    }
}
