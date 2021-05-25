using System;

namespace SpiralMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            string direction = "right";
            int row = 0;
            int col = 0;

            for (int i = 0; i < n * n; i++)
            {
                matrix[row, col] = i + 1;

                if (direction == "right")
                {
                    col++;
                }
                if (direction == "left")
                {
                    col--;
                }
                if (direction == "down")
                {
                    row++;
                }
                if (direction == "up")
                {
                    row--;
                }

                if (direction == "right" && (col == n || isEmpty(matrix, row, col, n)))
                {
                    direction = "down";
                    col--;
                    row++;
                    
                }
                if (direction == "down" && (row == n || isEmpty(matrix, row, col, n)))
                {
                    direction = "left";
                    col--;
                    row--;
                }
                if (direction == "left" && (col == -1 || isEmpty(matrix, row, col, n)))
                {
                    direction = "up";
                    col++;
                    row--;
                }
                if (direction == "up" && (row == -1 || isEmpty(matrix, row, col, n)))
                {
                    direction = "right";
                    col++;
                    row++;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] < 10)
                    {
                        Console.Write(" " + matrix[i, j] + " ");
                    }
                    else
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                }

                Console.WriteLine();
            }
        }

        private static bool isEmpty(int[,] matrix, int row, int col, int n)
        {
            return col >= 0 && col < n && row >= 0 && row < n && matrix[row, col] != 0;
        }
    }
}
