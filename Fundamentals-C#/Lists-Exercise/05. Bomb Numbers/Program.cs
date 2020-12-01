using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int[] bombProp = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int bomb = bombProp[0];
            int power = bombProp[1];

            for (int i = 0; i < nums.Count; i++)
            {
                int currentNum = nums[i];

                if (currentNum == bomb)
                {
                    int startIndex = i - power;
                    int endIndex = i + power;

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    if (endIndex > nums.Count - 1)
                    {
                        endIndex = nums.Count - 1;
                    }

                    int indexToRemove = endIndex - startIndex + 1;
                    nums.RemoveRange(startIndex, indexToRemove);

                    i = startIndex - 1;
                }
            }
            Console.WriteLine(nums.Sum());

        }
    }
}
