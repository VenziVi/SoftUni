using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int maxSum = 0;
            int maxSumRow = 0;
            int maxSumCol = 0;

            for (int row = 0; row < size[0] - 2; row++)
            {
                for (int col = 0; col < size[1] - 2; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                        + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                        + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxSumRow = row;
                        maxSumCol = col;
                    }
                }
            }


            Console.WriteLine($"Sum = {maxSum}");

            for (int i = maxSumRow; i < maxSumRow + 3; i++)
            {
                for (int j = maxSumCol; j < maxSumCol + 3; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
