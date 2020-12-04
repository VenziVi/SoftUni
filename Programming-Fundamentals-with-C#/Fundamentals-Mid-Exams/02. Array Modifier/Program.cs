using System;
using System.Linq;

namespace _02._Array_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] command = line.Split();
                string cmd = command[0];

                if (cmd == "swap")
                {
                    int firsIndex = int.Parse(command[1]);
                    int secondIndex = int.Parse(command[2]);
                    int firstIndexValue = nums[firsIndex];
                    int secondIndexValue = nums[secondIndex];
                    nums[firsIndex] = secondIndexValue;
                    nums[secondIndex] = firstIndexValue;
                }
                else if (cmd == "multiply")
                {
                    int firsIndex = int.Parse(command[1]);
                    int secondIndex = int.Parse(command[2]);
                    int firstIndexValue = nums[firsIndex];
                    int secondIndexValue = nums[secondIndex];
                    int result = firstIndexValue * secondIndexValue;
                    nums[firsIndex] = result;
                }
                else if (cmd == "decrease")
                {
                    for (int i = 0; i < nums.Length; i++)
                    {
                        nums[i] -= 1;
                    }
                }

                line = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
