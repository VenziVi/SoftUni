using System;

namespace _01.Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Done")
            {
                string[] input = command.Split();
                string cmd = input[0];

                if (cmd == "Change")
                {
                    string ch = input[1];
                    string replacment = input[2];
                    text = text.Replace(ch, replacment);
                    Console.WriteLine(text);
                }
                else if (cmd == "Includes")
                {
                    string includes = input[1];

                    if (text.Contains(includes))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (cmd == "End")
                {
                    string endString = input[1];

                    if (text.EndsWith(endString))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (cmd == "Uppercase")
                {
                    text = text.ToUpper();
                    Console.WriteLine(text);
                }
                else if (cmd == "FindIndex")
                {
                    string ch = input[1];
                    int index = text.IndexOf(ch);
                    Console.WriteLine(index);
                }
                else if (cmd == "Cut")
                {
                    int startindex = int.Parse(input[1]);
                    int length = int.Parse(input[2]);
                    text = text.Substring(startindex, length);
                    Console.WriteLine(text);
                }

                command = Console.ReadLine();
            }
        }
    }
}
