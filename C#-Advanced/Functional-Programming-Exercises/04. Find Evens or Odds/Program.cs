using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int start = nums[0];
            int end = nums[1];
            string type = Console.ReadLine();

            List<int> numbers = new List<int>(NumbersBetween(start, end));

            Predicate<int> predicate = n => true;

            if (type == "odd")
            {
                predicate = n => n % 2 != 0;
            }
            else if (type == "even")
            {
                predicate = n => n % 2 == 0;
            }

            Console.WriteLine(string.Join(" ", MyWhere(numbers, predicate)));
        }

        static List<int> MyWhere(List<int> numbers, Predicate<int> predicate) 
        {
            List<int> newNums = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (predicate(numbers[i]))
                {
                    newNums.Add(numbers[i]);
                }
            }

            return newNums;
        }



        private static List<int> NumbersBetween(int s, int e)
        {
            List<int> numbers = new List<int>();

            for (int i = s; i <= e; i++)
            {
                numbers.Add(i);
            }

            return numbers;
        }
    }
}
