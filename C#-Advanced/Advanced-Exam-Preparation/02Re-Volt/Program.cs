using System;

namespace _02Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            bool isPlayerWon = false;

            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < size; row++)
            {
                string currRow = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currRow[col];

                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();

                matrix[playerRow, playerCol] = '-';

                int playerOldRow = playerRow;
                int playerOldCol = playerCol;

                playerRow = MoveRow(playerRow, command);
                playerCol = MoveCol(playerCol, command);

                playerRow = IfInvalidRow(playerRow, size);
                playerCol = IfInvalidCol(playerCol, size);

                if (matrix[playerRow, playerCol] == 'B')
                {
                    playerRow = MoveRow(playerRow, command);
                    playerCol = MoveCol(playerCol, command);

                    playerRow = IfInvalidRow(playerRow, size);
                    playerCol = IfInvalidCol(playerCol, size);
                }

                if (matrix[playerRow, playerCol] == 'T')
                {
                    playerRow = playerOldRow;
                    playerCol = playerOldCol;
                }

                if (matrix[playerRow, playerCol] == 'F')
                {
                    matrix[playerRow, playerCol] = 'f';
                    isPlayerWon = true;
                    Console.WriteLine("Player won!");
                    break;
                }

                matrix[playerRow, playerCol] = 'f';
            }

            if (!isPlayerWon)
            {
                Console.WriteLine("Player lost!");
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        public static int MoveRow(int row, string movement)
        {
            if (movement == "up")
            {
                return row - 1;
            }
            if (movement == "down")
            {
                return row + 1;
            }

            return row;
        }

        public static int MoveCol(int col, string movement)
        {
            if (movement == "left")
            {
                return col - 1;
            }
            if (movement == "right")
            {
                return col + 1;
            }

            return col;
        }

        public static int IfInvalidRow(int playerRow, int size)
        {
            if (playerRow < 0)
            {
                playerRow = size - 1;
            }
            else if (playerRow >= size)
            {
                playerRow = 0;
            }

            return playerRow;
        }

        public static int IfInvalidCol(int playerCol, int size)
        {
            if (playerCol < 0)
            {
                playerCol = size - 1;
            }
            else if (playerCol >= size)
            {
                playerCol = 0;
            }

            return playerCol;
        }

    }
}
