using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> parking = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                string cmd = command[0];
                string username = command[1];

                if (cmd == "register")
                {
                    string plateNumber = command[2];
                    if (parking.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {plateNumber}");
                    }
                    else
                    {
                        parking.Add(username, plateNumber);
                        Console.WriteLine($"{username} registered {plateNumber} successfully");
                    }
                }
                else if (cmd == "unregister")
                {
                    if (!parking.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        parking.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                }
            }

            foreach (var name in parking)
            {
                Console.WriteLine($"{name.Key} => {name.Value}");
            }
        }
    }
}
