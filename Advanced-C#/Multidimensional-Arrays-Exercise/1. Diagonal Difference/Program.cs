using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int firstSum = 0;
            int secondSum = 0;

            for (int i = 0; i < n; i++)
            {
                firstSum += matrix[i, i];
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                secondSum += matrix[row, n - 1 - row];

            }

            int result = Math.Abs(firstSum - secondSum);
            Console.WriteLine(result);

        }
    }
}
