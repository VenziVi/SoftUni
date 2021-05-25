using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var pieces = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("|");
                string piece = input[0];
                string composer = input[1];
                string key = input[2];

                pieces.Add(piece, new List<string> { composer, key });
            }

            string command = Console.ReadLine();

            while (command != "Stop")
            {
                string[] cmdArgs = command.Split("|");
                string cmd = cmdArgs[0];
                string piece = cmdArgs[1];

                if (cmd == "Add")
                {
                    string composer = cmdArgs[2];
                    string key = cmdArgs[3];

                    if (pieces.ContainsKey(piece))
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                    else
                    {
                        pieces.Add(piece, new List<string> { composer, key });
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }

                }
                else if (cmd == "Remove")
                {
                    if (pieces.ContainsKey(piece))
                    {
                        pieces.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (cmd == "ChangeKey")
                {
                    string keyNew = cmdArgs[2];

                    if (pieces.ContainsKey(piece))
                    {
                        pieces[piece][1] = keyNew;
                        Console.WriteLine($"Changed the key of {piece} to {keyNew}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var piece in pieces.OrderBy(x => x.Key)
                .ThenBy(x => x.Value[0]))
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value[0]}, Key: {piece.Value[1]}");
            }
        }
    }
}
