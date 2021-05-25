using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool isFound = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char currSymbol = matrix[row, col];

                    if (currSymbol == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        isFound = true;
                        return;
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
