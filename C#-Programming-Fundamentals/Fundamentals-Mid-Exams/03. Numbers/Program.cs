using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            List<int> greaterNums = new List<int>();
            double sum = 0.0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }

            double average = sum / nums.Length;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > average)
                {
                    greaterNums.Add(nums[i]);
                }
            }

            if (greaterNums.Count == 0)
            {
                Console.WriteLine("No");
                return;
            }

            greaterNums.Sort();
            greaterNums.Reverse();

            while (greaterNums.Count > 5)
            {
                greaterNums.RemoveAt(greaterNums.Count - 1);
            }

            Console.WriteLine(string.Join(" ", greaterNums));
        }
    }
}
