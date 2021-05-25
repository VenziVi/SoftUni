using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            var users = new Dictionary<string, List<int>>();
            string command = Console.ReadLine();

            while (command != "Statistics")
            {
                string[] input = command.Split("=");
                string cmd = input[0];

                if (cmd == "Add")
                {
                    string username = input[1];
                    int send = int.Parse(input[2]);
                    int received = int.Parse(input[3]);

                    if (!users.ContainsKey(username))
                    {
                        users.Add(username, new List<int> { send, received });
                    }
                }
                else if (cmd == "Message")
                {
                    string sender = input[1];
                    string receiver = input[2];

                    if (users.ContainsKey(sender) && users.ContainsKey(receiver))
                    {
                        users[sender][0] += 1;
                        users[receiver][1] += 1;

                        if (users[sender][0] + users[sender][1] >= capacity)
                        {
                            Console.WriteLine($"{sender} reached the capacity!");
                            users.Remove(sender);
                        }
                        if (users[receiver][1] + users[receiver][0] >= capacity)
                        {
                            Console.WriteLine($"{receiver} reached the capacity!");
                            users.Remove(receiver);
                        }
                    }

                }
                else if (cmd == "Empty")
                {
                    string username = input[1];

                    if (username == "All")
                    {
                        users.Clear();
                    }
                    if (users.ContainsKey(username))
                    {
                        users.Remove(username);
                    }
                }

                command = Console.ReadLine();
            }
            
            Console.WriteLine($"Users count: {users.Count}");

            foreach (var user in users.OrderByDescending(x => x.Value[1])
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key} - {user.Value[0] + user.Value[1]}");
            }
        }
    }
}
