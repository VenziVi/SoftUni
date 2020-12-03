using System;
using System.Linq;

namespace _04._Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderByDescending(n => n)
                .ToArray();

            if (nums.Length < 3)
            {
                Console.WriteLine(string.Join(" ", nums));
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{nums[i]} ");
                }
            }

        }
    }
}
