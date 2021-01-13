using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // 3 + 4  * 2 / ( 1 - 5 )

            string[] expression = Console.ReadLine().Split(' ');

            Stack<string> operatorStack = new Stack<string>();
            string output = string.Empty;

            for (int i = 0; i < expression.Length; i++)
            {
                if (IsOperator(expression[i]))
                {
                    if (operatorStack.Count > 0)
                    {
                        var oldElementArity = OperationPrecedence
                            (operatorStack.Peek());
                        var elementArity = OperationPrecedence
                            (expression[i]);

                        if (oldElementArity >= elementArity)
                        {
                            output += operatorStack.Pop() + " ";
                        }
                    }
                    operatorStack.Push(expression[i]);

                }
                else if (expression[i] == "(")
                {
                    operatorStack.Push(expression[i]);
                }
                else if (expression[i] == ")")
                {
                    while (operatorStack.Peek() != "(")
                    {
                        output += operatorStack.Pop() + " ";
                    }

                    operatorStack.Pop();
                }
                else
                {
                    output += expression[i] + " ";
                }
            }

            while (operatorStack.Count > 0)
            {
                output += operatorStack.Pop() + " ";
            }

            string[] RPNExpression = output.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Reverse().ToArray();
            Stack<string> stack = new Stack<string>(RPNExpression);


            while (stack.Count > 1)
            {
                List<string> elements = new List<string>();
                var currentElement = stack.Pop();
                while (!IsOperator(currentElement))
                {
                    elements.Add(currentElement);
                    currentElement = stack.Pop();
                }

                int firstNum = int.Parse(elements[elements.Count - 2]);
                int secondNum = int.Parse(elements[elements.Count - 1]);

                int result = PerformOperation(currentElement, firstNum, secondNum);

                stack.Push(result.ToString());

                for (int i = elements.Count - 3; i >= 0; i--)
                {
                    stack.Push(elements[i]);
                }
            }

            Console.WriteLine($"result = {stack.Peek()}");
        }

        private static int PerformOperation(string currentElement, int firstNum, int secondNum)
        {
            switch (currentElement)
            {
                case "+":
                    return firstNum + secondNum;
                case "-":
                    return firstNum - secondNum;
                case "/":
                    return firstNum / secondNum;
                case "*":
                    return firstNum * secondNum;
                default:
                    break;
            }

            throw new NotImplementedException();
        }

        static int OperationPrecedence(string input)
        {
            switch (input)
            {
                case "+":
                    return 2;
                case "-":
                    return 2;
                case "/":
                    return 3;
                case "*":
                    return 3;
                case "(":
                    return 1;
                default:
                    break;
            }
            throw new ArgumentException();
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
    }
}
