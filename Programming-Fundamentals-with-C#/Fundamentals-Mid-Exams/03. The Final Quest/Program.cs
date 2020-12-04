using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._The_Final_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> text = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();

            while (command != "Stop")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string cmd = cmdArgs[0];
                

                if (cmd == "Delete")
                {
                    int index = int.Parse(cmdArgs[1]);
                    if (index >= 0 && index < text.Count - 1)
                    {
                        text.RemoveAt(index + 1);
                    }
                }
                else if (cmd == "Swap")
                {
                    string word1 = cmdArgs[1];
                    string word2 = cmdArgs[2];
                    if (text.Contains(word1) && text.Contains(word2))
                    {
                        int word1Index = text.IndexOf(word1);
                        int word2Index = text.IndexOf(word2);

                        text[word1Index] = word2;
                        text[word2Index] = word1;
                    }
                }
                else if (cmd == "Put")
                {
                    string word1 = cmdArgs[1];
                    int index = int.Parse(cmdArgs[2]);
                    if (index > 0 && index <= text.Count + 1)
                    {
                        text.Insert(index - 1, word1);
                    }
                }
                else if (cmd == "Sort")
                {

                    text = text.OrderByDescending(x => x).ToList();
                    //text.Sort();
                    //text.Reverse();
                }
                else if (cmd == "Replace")
                {
                    string word1 = cmdArgs[1];
                    string word2 = cmdArgs[2];
                    if (text.Contains(word2))
                    {
                        int word2Index = text.IndexOf(word2);
                        text[word2Index] = word1;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", text));
        }
    }
}
