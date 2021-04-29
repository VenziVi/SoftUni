using System;

namespace Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string cordinates = Console.ReadLine();
            char[,] matrix = new char[n,n];

            int firstPlayerShips = 0;
            int secondPlayerShips = 0;
            int destroyedShips = 0;

            for (int row = 0; row < n; row++)
            {
                string[] input = Console.ReadLine().Split();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = char.Parse(input[col]);

                    if (matrix[row, col] == '<')
                    {
                        firstPlayerShips++;
                    }

                    if (matrix[row, col] == '>')
                    {
                        secondPlayerShips++;
                    }
                }
            }

            string[] currCordinates = cordinates.Split(',');

            for (int i = 0; i < currCordinates.Length; i++)
            {
                string[] usedCord = currCordinates[i].Split();

                int currRow = int.Parse(usedCord[0]);
                int currCol = int.Parse(usedCord[1]);

                if (isCordinatesValid(currRow, currCol, n))
                {
                    if (matrix[currRow, currCol] == '<')
                    {
                        firstPlayerShips--;
                        destroyedShips++;
                        matrix[currRow, currCol] = 'X';
                    }

                    if (matrix[currRow, currCol] == '>')
                    {
                        secondPlayerShips--;
                        destroyedShips++;
                        matrix[currRow, currCol] = 'X';
                    }

                    if (matrix[currRow, currCol] == '#')
                    {
                        matrix[currRow, currCol] = 'X';


                        if (isCordinatesValid(currRow - 1, currCol, n))
                        {
                            if (matrix[currRow - 1, currCol] == '<')
                            {
                                firstPlayerShips--;
                                destroyedShips++;
                                matrix[currRow - 1, currCol] = 'X';
                            }

                            if (matrix[currRow - 1, currCol] == '>')
                            {
                                secondPlayerShips--;
                                destroyedShips++;
                                matrix[currRow - 1, currCol] = 'X';
                            }
                        }

                        if (isCordinatesValid(currRow - 1, currCol + 1, n))
                        {
                            if (matrix[currRow - 1, currCol + 1] == '<')
                            {
                                firstPlayerShips--;
                                destroyedShips++;
                                matrix[currRow - 1, currCol + 1] = 'X';
                            }

                            if (matrix[currRow - 1, currCol + 1] == '>')
                            {
                                secondPlayerShips--;
                                destroyedShips++;
                                matrix[currRow - 1, currCol + 1] = 'X';
                            }
                        }

                        if (isCordinatesValid(currRow, currCol + 1, n))
                        {
                            if (matrix[currRow, currCol + 1] == '<')
                            {
                                firstPlayerShips--;
                                destroyedShips++;
                                matrix[currRow, currCol + 1] = 'X';
                            }

                            if (matrix[currRow, currCol + 1] == '>')
                            {
                                secondPlayerShips--;
                                destroyedShips++;
                                matrix[currRow, currCol + 1] = 'X';
                            }
                        }

                        if (isCordinatesValid(currRow + 1, currCol + 1, n))
                        {
                            if (matrix[currRow + 1, currCol + 1] == '<')
                            {
                                firstPlayerShips--;
                                destroyedShips++;
                                matrix[currRow + 1, currCol + 1] = 'X';
                            }

                            if (matrix[currRow + 1, currCol + 1] == '>')
                            {
                                secondPlayerShips--;
                                destroyedShips++;
                                matrix[currRow + 1, currCol + 1] = 'X';
                            }
                        }

                        if (isCordinatesValid(currRow + 1, currCol, n))
                        {
                            if (matrix[currRow + 1, currCol] == '<')
                            {
                                firstPlayerShips--;
                                destroyedShips++;
                                matrix[currRow + 1, currCol] = 'X';
                            }

                            if (matrix[currRow + 1, currCol] == '>')
                            {
                                secondPlayerShips--;
                                destroyedShips++;
                                matrix[currRow + 1, currCol] = 'X';
                            }
                        }

                        if (isCordinatesValid(currRow + 1, currCol - 1, n))
                        {
                            if (matrix[currRow + 1, currCol - 1] == '<')
                            {
                                firstPlayerShips--;
                                destroyedShips++;
                                matrix[currRow + 1, currCol - 1] = 'X';
                            }

                            if (matrix[currRow + 1, currCol - 1] == '>')
                            {
                                secondPlayerShips--;
                                destroyedShips++;
                                matrix[currRow + 1, currCol - 1] = 'X';
                            }
                        }

                        if (isCordinatesValid(currRow, currCol - 1, n))
                        {
                            if (matrix[currRow, currCol - 1] == '<')
                            {
                                firstPlayerShips--;
                                destroyedShips++;
                                matrix[currRow, currCol - 1] = 'X';
                            }

                            if (matrix[currRow, currCol - 1] == '>')
                            {
                                secondPlayerShips--;
                                destroyedShips++;
                                matrix[currRow, currCol - 1] = 'X';
                            }
                        }

                        if (isCordinatesValid(currRow - 1, currCol - 1, n))
                        {
                            if (matrix[currRow - 1, currCol - 1] == '<')
                            {
                                firstPlayerShips--;
                                destroyedShips++;
                                matrix[currRow - 1, currCol - 1] = 'X';
                            }

                            if (matrix[currRow - 1, currCol - 1] == '>')
                            {
                                secondPlayerShips--;
                                destroyedShips++;
                                matrix[currRow - 1, currCol - 1] = 'X';
                            }
                        }
                    }
                }
            }

            if (secondPlayerShips == 0 && firstPlayerShips > 0)
            {
                Console.WriteLine($"Player One has won the game! {destroyedShips} ships have been sunk in the battle.");
            }
            else if (secondPlayerShips > 0 && firstPlayerShips == 0)
            {
                Console.WriteLine($"Player Two has won the game! {destroyedShips} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayerShips} ships left. Player Two has {secondPlayerShips} ships left.");
            }

            //for (int row = 0; row < n; row++)
            //{
            //    for (int col = 0; col < n; col++)
            //    {
            //        Console.Write(matrix[row, col] + " ");
            //    }
            //    Console.WriteLine();
            //}
        }

        private static bool isCordinatesValid(int currRow, int currCol, int n)
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
