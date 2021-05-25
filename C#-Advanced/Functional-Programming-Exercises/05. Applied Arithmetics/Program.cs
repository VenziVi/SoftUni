using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();
            Func<int, int> result = n => n;
            Action<List<int>> print = n => Console.WriteLine(string.Join(" ", nums));

            while (input != "end")
            {
                if (input == "add")
                {
                    result = n => n + 1;
                    nums = nums.Select(n => result(n)).ToList();
                }
                else if (input == "multiply")
                {
                    result = n => n * 2;
                    nums = nums.Select(n => result(n)).ToList();
                }
                else if (input == "subtract")
                {
                    result = n => n - 1;
                    nums = nums.Select(n => result(n)).ToList();
                }
                else if (input == "print")
                {
                    print(nums);
                }

                input = Console.ReadLine();
            }
        }
    }
}
