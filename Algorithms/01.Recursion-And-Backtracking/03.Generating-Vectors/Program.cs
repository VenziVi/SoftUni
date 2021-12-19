using System;

namespace _3.GeneratingVectors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];
            Generate(arr, 0);
        }

        private static void Generate(int[] arr, int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(String.Join("", arr));
                return;
            }
            
            for (int i = 0; i < 2; i++)
            {
                arr[index] = i;
                Generate(arr, index + 1);
            }
        }
    }
}
