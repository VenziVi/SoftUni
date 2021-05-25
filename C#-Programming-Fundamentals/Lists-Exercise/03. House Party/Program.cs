using System;
using System.Collections.Generic;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> guests = new List<string>();
            
            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string guestName = cmdArgs[0];

                if (cmdArgs.Length > 3)
                {
                    if (guests.Contains(guestName))
                    {
                        guests.Remove(guestName);
                    }
                    else
                    {
                        Console.WriteLine($"{guestName} is not in the list!");
                    }
                }
                else
                {
                    if (guests.Contains(guestName))
                    {
                        Console.WriteLine($"{guestName} is already in the list!");
                    }
                    else
                    {
                        guests.Add(guestName);
                    }
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, guests));
        }
    }
}
