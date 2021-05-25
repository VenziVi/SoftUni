using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = input[0];
            int m = input[1];
            HashSet<int> setN = new HashSet<int>();
            HashSet<int> setM = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                var num = int.Parse(Console.ReadLine());
                setN.Add(num);
            }
            for (int i = 0; i < m; i++)
            {
                var num = int.Parse(Console.ReadLine());
                setM.Add(num);
            }

            foreach (var numN in setN)
            {
                foreach (var numM in setM)
                {
                    if (numM == numN)
                    {
                        Console.Write($"{numN} ");
                    }
                }
            }
        }
    }
}
