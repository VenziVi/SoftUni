using System;
using System.Linq;

namespace _03._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] arr1 = new string[n];
            string[] arr2 = new string[n];

            for (int i = 0; i < n; i++)
            {
                string[] currentNum = Console.ReadLine()
                                             .Split();
                                             
                string zeroElement = currentNum[0];
                string firstElement = currentNum[1];

                if (i % 2 == 0)
                {
                    arr1[i] = zeroElement;
                    arr2[i] = firstElement;
                }
                else
                {
                    arr1[i] = firstElement;
                    arr2[i] = zeroElement;
                } 
            }
            Console.WriteLine(string.Join(" ", arr1));
            Console.WriteLine(string.Join(" ", arr2)); 
        }
    }
}
