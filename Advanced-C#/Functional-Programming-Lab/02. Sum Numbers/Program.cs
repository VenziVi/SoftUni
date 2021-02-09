using System;
using System.Linq;

namespace _02._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int count = nums.Length;
            int sum = nums.Sum();

            Console.WriteLine(count);
            Console.WriteLine(sum);                                            
        }
    }
}
