using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //2 3 1 4 - * * 5 *
            string[] expression = Console.ReadLine().Split(' ')
                .Reverse().ToArray();
            Stack<string> stack = new Stack<string>(expression);
            PrintStack(stack);

            while (stack.Count > 1)
            {
                List<string> elements = new List<string>();
                var currentElement = stack.Pop();
                while (!IsOperator(currentElement))
                {
                    elements.Add(currentElement);
                    currentElement = stack.Pop();
                }

                int first = int.Parse(elements[elements.Count - 2]);
                int second = int.Parse(elements[elements.Count - 1]);

                int result = PerformOperation(currentElement, first, second);

                stack.Push(result.ToString());

                for (int i = elements.Count - 3; i >= 0; i--)
                {
                    stack.Push(elements[i]);
                }

                PrintStack(stack);
            }
        }

        private static int PerformOperation(string currentElement, int first, int second)
        {
            switch (currentElement)
            {
                case "+":
                    return first + second;
                case "-":
                    return first - second;
                case "/":
                    return first / second;
                case "*":
                    return first * second;
                default:
                    break;
            }

            throw new NotImplementedException();
        }

        static bool IsOperator(string input) 
        {
            switch (input)
            {
                case "+":
                    return true;
                case "-":
                    return true;
                case "/":
                    return true;
                case "*":
                    return true;
                default:
                    break;
            }
            return false;
        }

        static void PrintStack(Stack<string> stack)
        {
            foreach (var item in stack)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
