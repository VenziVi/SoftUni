using System;
using System.Collections.Generic;

namespace _9._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string text = string.Empty;
            Stack<string> undo = new Stack<string>();
            undo.Push(text);

            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();
                string[] input = command.Split();
                string cmd = input[0];

                if (cmd == "1")
                {
                    string newText = input[1];
                    text = text.Insert(text.Length, newText);
                    undo.Push(text);
                }
                else if (cmd == "2")
                {
                    int countToErase = int.Parse(input[1]);
                    text = text.Remove(text.Length - countToErase, countToErase);
                    undo.Push(text);
                }
                else if (cmd == "3")
                {
                    int index = int.Parse(input[1]) - 1;
                    if (text.Length >= index)
                    {
                        string letter = text.Substring(index, 1);
                        Console.WriteLine(letter);
                    }
                }
                else if (cmd == "4")
                {
                    undo.Pop();
                    text = undo.Peek();
                }
            }
        }
    }
}
