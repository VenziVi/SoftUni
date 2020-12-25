using System;
using System.Linq;

namespace _01._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string raw = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Generate")
            {
                string[] line = input.Split(">>>");
                string command = line[0];

                //Contains >>>{ substring} – checks if the raw activation key contains the given substring.
                //         If it does prints: "{raw activation key} contains {substring}".
                //         If not, prints: "Substring not found!"
                //Flip >>> Upper / Lower >>>{ startIndex}>>>{ endIndex}
                //         Changes the substring between the given indices(the end index is exclusive) to upper or lower case. 
                //         All given indexes will be valid.
                //         Prints the activation key.
                //Slice >>>{ startIndex}>>>{ endIndex}
                //         Deletes the characters between the start and end indices(end index is exclusive).
                //         Both indices will be valid.
                //         Prints the activation key.

                if (command == "Contains")
                {
                    string substring = line[1];

                    if (raw.Contains(substring))
                    {
                        Console.WriteLine($"{raw} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                if (command == "Flip")
                {
                    string type = line[1];
                    int startIndex = int.Parse(line[2]);
                    int endIndex = int.Parse(line[3]);
                    int count = endIndex - startIndex;

                    if (type == "Upper")
                    {
                        string firstpart = raw.Substring(0, startIndex);
                        string neededPart = raw.Substring(startIndex, count);
                        string lastPart = raw.Substring(endIndex);

                        neededPart = neededPart.ToUpper();

                        raw = firstpart + neededPart + lastPart;
                    }
                    else if (type == "Lower")
                    {
                        raw = raw.Substring(0, startIndex) +
                            raw.Substring(startIndex, count).ToLower() +
                            raw.Substring(endIndex);
                    }

                    Console.WriteLine(raw);
                }

                if (command == "Slice")
                {
                    int startIndex = int.Parse(line[1]);
                    int endIndex = int.Parse(line[2]);
                    int count = endIndex - startIndex;
                    raw = raw.Remove(startIndex, count);
                    Console.WriteLine(raw);
                }

              input = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {raw}");
        }
    }
}
