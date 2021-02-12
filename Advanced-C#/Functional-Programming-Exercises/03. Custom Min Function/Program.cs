using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int[], int> minNum = num => 
            {
                int minNum = int.MaxValue;
                foreach (var item in nums)
                {
                    if (item < minNum)
                    {
                        minNum = item;
                    }
                }

                return minNum;
            };

            Console.WriteLine(minNum(nums));
        }
    }
}
