using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ReverseArray
{
    internal class Program
    {
        private static string[] input;
        //private static List<string> result;
        static void Main(string[] args)
        {
            input = Console.ReadLine().Split();
            //result = new List<string>(input.Length);
            //ReverseArr(0);
            Reverse(0);
            //Console.WriteLine(string.Join(" ", result));
            Console.WriteLine(string.Join(" ", input));
        }

        private static void Reverse(int index)
        {
            if (index == input.Length / 2)
            {
                return;
            }

            var temp = input[index];
            input[index] = input[input.Length - index - 1];
            input[input.Length - index - 1] = temp;

            Reverse(index + 1);
        }

        //private static void ReverseArr(int index)
        //{
        //    if (index >= input.Length)
        //    {
        //        return;
        //    }

        //    ReverseArr(index + 1);
        //    result.Add(input[index]);
        //}
    }
}
