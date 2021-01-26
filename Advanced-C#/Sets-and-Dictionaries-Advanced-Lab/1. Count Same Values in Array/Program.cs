using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> nums = new Dictionary<double, int>();
            double[] array = Console.ReadLine().Split().Select(double.Parse).ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                if (!nums.ContainsKey(array[i]))
                {
                    nums.Add(array[i], 0);
                }

                nums[array[i]]++;
            }

            foreach (var num in nums)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }
        }
    }
}
