using System;

namespace _01._The_Imitation_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Decode")
            {
                string[] tokens = command.Split("|");
                string input = tokens[0];

                if (input == "Move")
                {
                    int numberOfLetters = int.Parse(tokens[1]);
                    string substring = message.Substring(0, numberOfLetters);
                    message = message.Remove(0, numberOfLetters);
                    message = message.Insert(message.Length, substring);
                }
                else if (input == "Insert")
                {
                    int index = int.Parse(tokens[1]);
                    string value = tokens[2];
                    message = message.Insert(index, value);
                }
                else if (input == "ChangeAll")
                {
                    string oldSubstring = tokens[1];
                    string newString = tokens[2];
                    message = message.Replace(oldSubstring, newString);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
