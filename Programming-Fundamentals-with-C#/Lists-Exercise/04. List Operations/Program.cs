using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string commands = Console.ReadLine();

            while (commands != "End")
            {
                string[] cmd = commands.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string currentCmd = cmd[0];

                if (currentCmd == "Add")
                {
                    nums.Add(int.Parse(cmd[1]));
                }
                else if (currentCmd == "Insert")
                {
                    int index = int.Parse(cmd[2]);

                    if (IsValidIndex(index, nums.Count))
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        nums.Insert(index, int.Parse(cmd[1]));
                    }
                }
                else if (currentCmd == "Remove")
                {
                    int index = int.Parse(cmd[1]);

                    if (IsValidIndex(index, nums.Count))
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        nums.RemoveAt(index);
                    }
                }
                else if (currentCmd == "Shift")
                {
                    int rotate = int.Parse(cmd[2]);
                    if (cmd[1] == "left")
                    {
                        for (int i = 0; i < rotate; i++)
                        {
                            int firstElement = nums[0];

                            for (int j = 0; j < nums.Count - 1; j++)
                            {
                                nums[j] = nums[j + 1];
                            }
                            nums[nums.Count - 1] = firstElement;
                        }
                    }
                    else if (cmd[1] == "right")
                    {
                        for (int i = 0; i < rotate; i++)
                        {
                            int lastElement = nums[nums.Count - 1];

                            for (int j = nums.Count - 1; j > 0; j--)
                            {
                                nums[j] = nums[j - 1];
                            }
                            nums[0] = lastElement;
                        }
                    }
                }
                commands = Console.ReadLine();
            }
            Console.WriteLine(string.Join(' ', nums));
        }

        private static bool IsValidIndex(int index, int count)
        {
            return index > count || index < 0;
        }
    }
}
