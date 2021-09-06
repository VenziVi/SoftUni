namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {

            Queue<char> queue = new Queue<char>(parentheses);

            int counter = 0;
            bool check = true;

            if (queue.Count % 2 != 0)
            {
                return false;
            }

            while (queue.Any())
            {
                var first = queue.Dequeue();
                var next = queue.Peek();

                if (first == '{')
                {
                    if (next == '}')
                    {
                        queue.Dequeue();
                        counter = 0;
                        continue;
                    }
                    else
                    {
                        queue.Enqueue(first);
                    }
                }
                else if (first == '(')
                {
                    if (next == ')')
                    {
                        queue.Dequeue();
                        counter = 0;
                        continue;
                    }
                    else
                    {
                        queue.Enqueue(first);
                    }
                }
                else if (first == '[')
                {
                    if (next == ']')
                    {
                        queue.Dequeue();
                        counter = 0;
                        continue;
                    }
                    else
                    {
                        queue.Enqueue(first);
                    }
                }
                else
                {
                    queue.Enqueue(first);
                }

                counter++;

                if (counter == queue.Count)
                {
                    check = false;
                    break;
                }
            }

            if (check)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
