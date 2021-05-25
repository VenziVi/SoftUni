using System;
using System.Linq;

namespace _06._Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                               .Split(" ")
                               .Select(int.Parse)
                               .ToArray();

            bool isFound = false;

            for (int i = 0; i < arr.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;
                int currentNum = arr[i];

                for (int j = 0; j < i; j++)
                {
                    leftSum += arr[j];
                    
                }
                for (int k = i + 1; k < arr.Length; k++)
                {
                    rightSum += arr[k];
                    
                }
                if (rightSum == leftSum)
                {
                    Console.WriteLine(i);
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                Console.WriteLine("no");
            }
        } 
    }
}
