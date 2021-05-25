using System;

namespace Knightgame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int knightsToRemove = 0;

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int currRow = 0;
            int currCol = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == 'K')
                    {
                        currRow = row;
                        currCol = col;

                        if (isValidCell(currRow - 1, currCol - 2, n))
                        {
                            if (matrix[row - 1, col - 2] == 'K')
                            {
                                matrix[row - 1, col - 2] = '0';
                                knightsToRemove++;
                            }
                        }
                        if (isValidCell(currRow - 1, currCol + 2, n))
                        {
                            if (matrix[row - 1, col + 2] == 'K')
                            {
                                matrix[row - 1, col + 2] = '0';
                                knightsToRemove++;
                            }
                        }
                        if (isValidCell(currRow + 1, currCol - 2, n))
                        {
                            if (matrix[row + 1, col - 2] == 'K')
                            {
                                matrix[row + 1, col - 2] = '0';
                                knightsToRemove++;
                            }
                        }
                        if (isValidCell(currRow + 1, currCol + 2, n))
                        {
                            if (matrix[row + 1, col + 2] == 'K')
                            {
                                matrix[row + 1, col + 2] = '0';
                                knightsToRemove++;
                            }
                        }
                        if (isValidCell(currRow - 2, currCol - 1, n))
                        {
                            if (matrix[row - 2, col - 1] == 'K')
                            {
                                matrix[row - 2, col - 1] = '0';
                                knightsToRemove++;
                            }
                        }
                        if (isValidCell(currRow - 2, currCol + 1, n))
                        {
                            if (matrix[row - 2, col + 1] == 'K')
                            {
                                matrix[row - 2, col + 1] = '0';
                                knightsToRemove++;
                            }
                        }
                        if (isValidCell(currRow + 2, currCol - 1, n))
                        {
                            if (matrix[row + 2, col - 1] == 'K')
                            {
                                matrix[row + 2, col - 1] = '0';
                                knightsToRemove++;
                            }
                        }
                        if (isValidCell(currRow + 2, currCol + 1, n))
                        {
                            if (matrix[row + 2, col + 1] == 'k')
                            {
                                matrix[row + 2, col + 1] = '0';
                                knightsToRemove++;
                            }
                        }
                    }
                }               
            }

            Console.WriteLine(knightsToRemove);
        }

        private static bool isValidCell(int currRow, int currCol, int n)
        {
            if (currRow < 0 || currRow >= n)
            {
                return false;
            }

            if (currCol < 0 || currCol >= n)
            {
                return false;
            }

            return true;
        }
    }
}
