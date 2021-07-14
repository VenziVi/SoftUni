using System;

namespace EightQueens
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            
            Console.WriteLine(GetQueens(matrix, 0));            
        }

        private static int GetQueens(int[,] matrix, int row)
        {
            if (row == matrix.GetLength(0))
            {
                Print(matrix);
                Console.WriteLine();
                return 1;
            }

            int foundQueens = 0;

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (IsValid(matrix, row, col))
                {
                    matrix[row, col] = 1;
                    foundQueens += GetQueens(matrix, row + 1);
                    matrix[row, col] = 0;
                }
            }
            return foundQueens;
        }

        private static bool IsValid(int[,] matrix, int row, int col)
        {
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (row - i >= 0 && matrix[row - i, col] == 1)
                {
                    return false;
                }
                if (col - i >= 0 && matrix[row, col - i] == 1)
                {
                    return false;
                }
                if (row + i < matrix.GetLength(0) && matrix[row + i, col] == 1)
                {
                    return false;
                }
                if (col + i < matrix.GetLength(0) && matrix[row, col + i] == 1)
                {
                    return false;
                }
                if (row + i < matrix.GetLength(0) &&
                    col + i < matrix.GetLength(0) &&
                    matrix[row + i, col + i] == 1)
                {
                    return false;
                }
                if (row + i < matrix.GetLength(0) &&
                    col - i >= 0 &&
                    matrix[row + i, col - i] == 1)
                {
                    return false;
                }
                if (row - i >= 0 &&
                    col - i >= 0 &&
                    matrix[row - i, col - i] == 1)
                {
                    return false;
                }
                if (row - i >= 0 &&
                    col + i < matrix.GetLength(0) &&
                    matrix[row - i, col + i] == 1)
                {
                    return false;
                }
            }
            return true;
        }

        static void Print(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 1)
                    {
                        Console.Write('Q' + " ");
                    }
                    if (matrix[row, col] == 0)
                    {
                        Console.Write('-' + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
