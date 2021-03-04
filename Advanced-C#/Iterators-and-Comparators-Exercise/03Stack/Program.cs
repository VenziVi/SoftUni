using System;
using System.Collections.Generic;

namespace _03Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            MyStack stack = new MyStack();
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] splited = command.Split(new string[] { " ", ", "}, StringSplitOptions.RemoveEmptyEntries);
                string cmdArg = splited[0];

                switch (cmdArg)
                {
                    case "Push":
                        for (int i = 1; i < splited.Length; i++)
                        {
                            stack.Push(int.Parse(splited[i]));
                        }
                        break;

                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    default:
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, stack));
            Console.WriteLine(string.Join(Environment.NewLine, stack));
        }
    }
}
