using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> nums = new Stack<int>(input);
            string command = Console.ReadLine().ToLower();

            while (command != "end")
            {
                string[] cmdArgs = command.Split();
                string cmd = cmdArgs[0];

                if (cmd == "add")
                {
                    nums.Push(int.Parse(cmdArgs[1]));
                    nums.Push(int.Parse(cmdArgs[2]));

                }
                else if (cmd == "remove")
                {
                    if (nums.Count >= int.Parse(cmdArgs[1]))
                    {
                        for (int i = 0; i < int.Parse(cmdArgs[1]); i++)
                        {
                            nums.Pop();
                        }
                    }
                }

                command = Console.ReadLine().ToLower();
            }

            int[] finalNums = nums.ToArray();
            int sum = finalNums.Sum();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
