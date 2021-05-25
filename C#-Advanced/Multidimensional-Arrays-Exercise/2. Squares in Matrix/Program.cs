using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[,] matrix = new string[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                string[] input = Console.ReadLine().Split();

                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int numOfSquers = 0;

            for (int row = 0; row < size[0]; row++)
            {
                for (int col = 0; col < size[1]; col++)
                {
                    string symbol = matrix[row, col];

                    if (row == size[0] - 1 || col == size[1] - 1)
                    {
                        break;
                    }

                    if (symbol == matrix[row, col + 1] &&
                        symbol == matrix[row + 1, col] &&
                        symbol == matrix[row + 1, col + 1])
                    {
                        numOfSquers++;
                    }
                }
            }

            Console.WriteLine(numOfSquers);
        }
    }
}
