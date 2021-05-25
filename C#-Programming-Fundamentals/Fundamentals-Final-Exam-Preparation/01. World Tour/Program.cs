using System;

namespace _01._World_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Travel")
            {
                string[] input = command.Split(":");
                string cmd = input[0];

                if (cmd == "Add Stop")
                {
                    int index = int.Parse(input[1]);
                    string text = input[2];

                    if (index >= 0 && index < destination.Length + 1)
                    {
                        destination = destination.Insert(index, text);
                    }
                    Console.WriteLine(destination);
                }
                else if (cmd == "Remove Stop")
                {
                    int startIndex = int.Parse(input[1]);
                    int endIndex = int.Parse(input[2]);
                    int length = endIndex - startIndex + 1;

                    if (endIndex >= startIndex && startIndex >= 0 && length <= destination.Length - startIndex)
                    {
                        destination = destination.Remove(startIndex, length);
                    }

                    Console.WriteLine(destination);
                }
                else if (cmd == "Switch")
                {
                    string oldDestination = input[1];
                    string newDestination = input[2];

                    if (destination.Contains(oldDestination))
                    {
                        destination = destination.Replace(oldDestination, newDestination);
                    }
                    Console.WriteLine(destination);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {destination}");
        }
    }
}
