using System;
using System.Collections.Generic;

namespace _05.PathsInLabyrinth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, m];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            List<string> path = new List<string>();
            FindExit(matrix, 0, 0, string.Empty, path);
        }

        private static void FindExit(char[,] matrix, int row, int col, string direction, List<string> path)
        {
            if (!IsFieldValid(matrix, row, col))
            {
                return;
            }

            path.Add(direction);

            if (matrix[row, col] == 'e')
            {
                Console.WriteLine(string.Join("", path));
                path.RemoveAt(path.Count - 1);
                return;
            }

            matrix[row, col] = 'b';

            FindExit(matrix, row, col - 1, "L", path);
            FindExit(matrix, row, col + 1, "R", path);
            FindExit(matrix, row - 1, col, "U", path);
            FindExit(matrix, row + 1, col, "D", path);

            matrix[row, col] = '-';
            path.RemoveAt(path.Count - 1);
        }

        public static bool IsFieldValid(char[,] matrix, int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return false;
            }

            if (matrix[row, col] == '*' || matrix[row, col] == 'b')
            {
                return false;
            }

            return true;
        }
    }
}
