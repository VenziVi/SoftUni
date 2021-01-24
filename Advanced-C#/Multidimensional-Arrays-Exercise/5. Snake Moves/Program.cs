using System;
using System.Linq;
using System.Text;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            char[,] matrix = new char[size[0], size[1]];
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            int textLine = (size[0] * size[1]) / input.Length + 1;

            while (textLine > 0)
            {
                sb.Append(input);
                textLine--;
            }

            int nextCol = 0;

            for (int row = 0; row < size[0]; row++)
            {             
                if (row % 2 == 0)
                {
                    for (int col = 0; col < size[1]; col++)
                    {
                        matrix[row, col] = sb[nextCol];
                        nextCol++;
                    }
                }
                else
                {
                    for (int col = size[1] - 1; col >= 0; col--)
                    {
                        matrix[row, col] = sb[nextCol];
                        nextCol++;
                    }
                }
            }

            for (int row = 0; row < size[0]; row++)
            {
                for (int col = 0; col < size[1]; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}

