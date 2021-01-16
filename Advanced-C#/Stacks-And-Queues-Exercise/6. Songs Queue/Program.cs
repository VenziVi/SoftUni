using System;
using System.Collections.Generic;

namespace _6._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");
            string input = Console.ReadLine();
            Queue<string> playlist = new Queue<string>(songs);

            while (playlist.Count > 0)
            {
                string[] command = input.Split();
                string cmd = command[0];

                if (cmd == "Play")
                {
                    playlist.Dequeue();
                }
                else if (cmd == "Add")
                {
                    int endIndex = input.Length - 4;
                    string song = input.Substring(4, endIndex);

                    if (!playlist.Contains(song))
                    {
                        playlist.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (cmd == "Show")
                {
                    Console.WriteLine(string.Join(", ", playlist.ToArray()));
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("No more songs!");
        }
    }
}
