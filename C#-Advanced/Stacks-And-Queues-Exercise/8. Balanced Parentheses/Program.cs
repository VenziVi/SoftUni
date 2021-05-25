using System;
using System.Collections.Generic;

namespace _8._Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();
            Stack<char> brackets = new Stack<char>();

            for (int i = 0; i < input.Length / 2; i++)
            {
                if (input[i] == ')' ||
                    input[i] == '}' ||
                    input[i] == ']')
                {
                    Console.WriteLine("NO");
                    return;
                }
                else if (input[i] == '(' ||
                         input[i] == '{' ||
                         input[i] == '[')
                {
                    brackets.Push(input[i]);
                }
            }

            bool isBalanced = true;
            if (brackets.Count > 0)
            {
                for (int i = input.Length / 2; i < input.Length; i++)
                {
                    char bracket = brackets.Pop();

                    if (input[i] == ')' && bracket == '(')
                    {
                        isBalanced = true;
                    }
                    else if (input[i] == '}' && bracket == '{')
                    {
                        isBalanced = true;
                    }
                    else if (input[i] == ']' && bracket == '[')
                    {
                        isBalanced = true;
                    }
                    else
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("NO");
                return;
            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
