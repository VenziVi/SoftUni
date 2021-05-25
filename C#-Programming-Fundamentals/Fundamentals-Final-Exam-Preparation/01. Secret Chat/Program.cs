using System;
using System.Linq;

namespace _01._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Reveal")
            {
                string[] operations = command.Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string cmd = operations[0];

                if (cmd == "InsertSpace")
                {
                    int index = int.Parse(operations[1]);
                    message = message.Insert(index, " ");
                    Console.WriteLine(message);
                }
                else if (cmd == "Reverse")
                {
                    string substring = operations[1];

                    if (message.Contains(substring))
                    {
                        string reversed = string.Empty;
                        int index = message.IndexOf(substring);

                        string cutedString = message.Substring(index, substring.Length);
                        message = message.Remove(index, substring.Length);

                        for (int i = cutedString.Length - 1; i >= 0; i--)
                        {
                            reversed += cutedString[i];
                        }

                        message = message.Insert(message.Length, reversed);
                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }

                }
                else if (cmd == "ChangeAll")
                {
                    string substring = operations[1];
                    string replacment = operations[2];

                    message = message.Replace(substring, replacment);
                    Console.WriteLine(message);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
