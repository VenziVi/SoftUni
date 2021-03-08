using System;
using System.Collections.Generic;
using System.Linq;

namespace _02Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = 0;
                }
            }

            string command = Console.ReadLine();

            while (command != "Bloom Bloom Plow")
            {
                string[] splited = command.Split();
                int row = int.Parse(splited[0]);
                int col = int.Parse(splited[1]);

                if (IsPositionValid(row, col, size[0], size[1]))
                {
                    matrix[row, col] += 1;

                    for (int i = row + 1; i < size[0]; i++)
                    {
                        matrix[i, col] += 1;
                    }
                    for (int i = 0; i < row; i++)
                    {
                        matrix[i, col] += 1;
                    }

                    for (int i = col + 1; i < size[1]; i++)
                    {
                        matrix[row, i] += 1;
                    }
                    for (int i = 0; i < col; i++)
                    {
                        matrix[row, i] += 1;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }

                command = Console.ReadLine();
            }

            for (int row = 0; row < size[0]; row++)
            {
                for (int col = 0; col < size[1]; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        public static bool IsPositionValid(int row, int col, int rows, int cols)
        {
            if (row < 0 || row >= rows)
            {
                return false;
            }
            if (col < 0 || col >= cols)
            {
                return false;
            }

            return true;
        }
    }
}
