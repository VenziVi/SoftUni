using System;
using System.Linq;

namespace SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            
            char[,] matrix = new char[n, n];

            int marioRow = -1;
            int marioCol = -1;

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                
                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }
            }

            int cols = matrix.GetLength(1);

            while (true)
            {

                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                char direction = char.Parse(command[0]);
                int enemyRow = int.Parse(command[1]);
                int enemyCol = int.Parse(command[2]);

                matrix[enemyRow, enemyCol] = 'B';

                if (direction == 'W')
                {
                    if (positionIsValid(marioRow - 1, marioCol, n, cols))
                    {
                        matrix[marioRow, marioCol] = '-';
                        marioRow -= 1;
                        lives -= 1;

                        if (matrix[marioRow, marioCol] == 'B')
                        {
                            lives -= 2;

                            if (lives <= 0)
                            {
                                matrix[marioRow, marioCol] = 'X';
                                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                                break;
                            }

                            matrix[marioRow, marioCol] = '-';
                        }

                        if (matrix[marioRow, marioCol] == 'P')
                        {
                            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                            matrix[marioRow, marioCol] = '-';
                            break;
                        }
                    }
                    else
                    {
                        lives -= 1;
                    }
                }
                else if (direction == 'S')
                {
                    if (positionIsValid(marioRow + 1, marioCol, n, cols))
                    {
                        matrix[marioRow, marioCol] = '-';
                        marioRow += 1;
                        lives -= 1;

                        if (matrix[marioRow, marioCol] == 'B')
                        {
                            lives -= 2;

                            if (lives <= 0)
                            {
                                matrix[marioRow, marioCol] = 'X';
                                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                                break;
                            }

                            matrix[marioRow, marioCol] = '-';
                        }

                        if (matrix[marioRow, marioCol] == 'P')
                        {
                            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                            matrix[marioRow, marioCol] = '-';
                            break;
                        }
                    }
                    else
                    {
                        lives -= 1;

                    }
                }
                else if (direction == 'A')
                {
                    if (positionIsValid(marioRow, marioCol - 1, n, cols))
                    {
                        matrix[marioRow, marioCol] = '-';
                        marioCol -= 1;
                        lives -= 1;

                        if (matrix[marioRow, marioCol] == 'B')
                        {
                            lives -= 2;

                            if (lives <= 0)
                            {
                                matrix[marioRow, marioCol] = 'X';
                                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                                break;
                            }

                            matrix[marioRow, marioCol] = '-';
                        }

                        if (matrix[marioRow, marioCol] == 'P')
                        {
                            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                            matrix[marioRow, marioCol] = '-';
                            break;
                        }
                    }
                    else
                    {
                        lives -= 1;
                    }
                }
                else if (direction == 'D')
                {
                    if (positionIsValid(marioRow, marioCol + 1, n, cols))
                    {
                        matrix[marioRow, marioCol] = '-';
                        marioCol += 1;
                        lives -= 1;

                        if (matrix[marioRow, marioCol] == 'B')
                        {
                            lives -= 2;

                            if (lives <= 0)
                            {
                                matrix[marioRow, marioCol] = 'X';
                                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                                break;
                            }

                            matrix[marioRow, marioCol] = '-';
                        }

                        if (matrix[marioRow, marioCol] == 'P')
                        {
                            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                            matrix[marioRow, marioCol] = '-';
                            break;
                        }
                    }
                    else
                    {
                        lives -= 1;

                    }


                }

            }


            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static bool positionIsValid(int row, int col, int n, int cols)
        {
            if (row < 0 || row >= n)
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