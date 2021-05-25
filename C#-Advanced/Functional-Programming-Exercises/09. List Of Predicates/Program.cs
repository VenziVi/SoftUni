using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int endNum = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            HashSet<int> numbers = new HashSet<int>();

            Func<int, int[], HashSet<int>> numbersToPrint = (endNum, dividers) =>
            {
                bool isTrue = true;

                for (int i = 1; i <= endNum; i++)
                {
                    for (int j = 0; j < dividers.Length; j++)
                    {
                        if (i % dividers[j] != 0)
                        {
                            isTrue = false;
                        }
                    }

                    if (isTrue)
                    {
                        numbers.Add(i);
                    }

                    isTrue = true;
                }
                return numbers;
            };

            Action<HashSet<int>> print = nums => Console.Write(string.Join(" ", nums));
            print(numbersToPrint(endNum, dividers));
        }
    }
}
