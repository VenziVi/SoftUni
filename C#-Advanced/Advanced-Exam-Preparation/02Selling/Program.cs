using System;

namespace _02Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Char[,] matrix = new char[n, n];
            int money = 0;


            int selarRow = -1;
            int selarCol = -1;

            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];

                    if (currentRow[col] == 'S')
                    {
                        selarRow = row;
                        selarCol = col;
                    }
                }
            }

            string command = Console.ReadLine();

            while (money < 50)
            {
                matrix[selarRow, selarCol] = '-';

                selarRow = MoveRow(selarRow, command);
                selarCol = MoveCol(selarCol, command);

                if (!IsPositionValid(selarRow, selarCol, n, n))
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    Console.WriteLine($"Money: {money}");
                    break;
                }

                if (matrix[selarRow, selarCol] == 'O')
                {
                    matrix[selarRow, selarCol] = '-';

                    for (int row = 0; row < n; row++)
                    {
                        for (int col = 0; col < n; col++)
                        {
                            if (matrix[row, col] == 'O')
                            {
                                selarRow = row;
                                selarCol = col;
                            }
                        }
                    }

                }
                if (char.IsDigit(matrix[selarRow, selarCol]))
                {
                    string currDigit = matrix[selarRow, selarCol].ToString();
                    int wonMoney = int.Parse(currDigit);
                    money += wonMoney;
                }


                matrix[selarRow, selarCol] = 'S';

                command = Console.ReadLine();
            }

            if (money >= 50)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
                Console.WriteLine($"Money: {money}");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
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
