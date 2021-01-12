using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Stack<int> bracketIndex = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    bracketIndex.Push(i);
                }
                else if (input[i] == ')')
                {
                    int startIndex = bracketIndex.Pop();

                    Console.WriteLine(input.Substring(startIndex, i - startIndex +1));
                }
            }
        }
    }
}
