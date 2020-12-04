using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Last_Stop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string line = Console.ReadLine();

            while (line != "END")
            {
                string[] command = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string cmd = command[0];

                if (cmd == "Change")
                {
                    string num1 = command[1];
                    string num2 = command[2];

                    if (nums.Contains(num1))
                    {
                        int num1Index = nums.IndexOf(num1);
                        nums[num1Index] = num2;
                    }
                }
                else if (cmd == "Hide")
                {
                    string num = command[1];
                    if (nums.Contains(num))
                    {
                        nums.Remove(num);
                    }
                }
                else if (cmd == "Switch")
                {
                    string num1 = command[1];
                    string num2 = command[2];

                    if (nums.Contains(num1) && nums.Contains(num2))
                    {
                        int index1 = nums.IndexOf(num1);
                        int index2 = nums.IndexOf(num2);
                        nums[index1] = num2;
                        nums[index2] = num1;
                    }
                }
                else if (cmd == "Insert")
                {
                    int index = int.Parse(command[1]);
                    string number = command[2];
                    if (index >= 0 && index < nums.Count - 1)
                    {
                        nums.Insert(index + 1, number);
                    }

                }
                else if (cmd == "Reverse")
                {
                    nums.Reverse();
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
