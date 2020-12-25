using System;
using System.Linq;
using System.Text;

namespace _01._Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string input = Console.ReadLine();
            

            while (input != "Done")
            {
                string[] cmd = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string command = cmd[0];

                if (command == "TakeOdd")
                {
                    StringBuilder newPass = new StringBuilder();

                    for (int i = 0; i < password.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            newPass.Append(password[i]);
                        }
                    }
                    password = newPass.ToString();
                    Console.WriteLine(password);
                }
                else if (command == "Cut")
                {
                    int index = int.Parse(cmd[1]);
                    int length = int.Parse(cmd[2]);

                    password = password.Remove(index, length);
                    Console.WriteLine(password);
                }
                else if (command == "Substitute")
                {
                    string substring = cmd[1];
                    string substitute = cmd[2];

                    if (password.Contains(substring))
                    {
                        password = password.Replace(substring, substitute);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
