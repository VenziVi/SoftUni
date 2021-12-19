using System;
using System.Collections.Generic;

namespace _06.EightQueensPuzzle
{
    internal class Program
    {
        private static HashSet<int> attakedRows = new HashSet<int>();
        private static HashSet<int> attakedCols = new HashSet<int>();
        private static HashSet<int> attkedLeftDiagonals = new HashSet<int>();
        private static HashSet<int> attakedRightDiagonals = new HashSet<int>();

        static void Main(string[] args)
        {
            bool[,] board = new bool[8, 8];

            PutQueen(board, 0);
        }

        private static void PutQueen(bool[,] board, int row)
        {
            if (row >= board.GetLength(0))
            {
                PrintBoard(board);
                return;
            }

            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (CanPlaceQueen(row, col))
                {
                    attakedRows.Add(row);
                    attakedCols.Add(col);
                    attkedLeftDiagonals.Add(row - col);
                    attakedRightDiagonals.Add(row + col);
                    board[row, col] = true;

                    PutQueen(board, row + 1);

                    attakedRows.Remove(row);
                    attakedCols.Remove(col);
                    attkedLeftDiagonals.Remove(row - col);
                    attakedRightDiagonals.Remove(row + col);
                    board[row, col] = false;
                }
            }
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            return !attakedRows.Contains(row) &&
                    !attakedCols.Contains(col) &&
                    !attkedLeftDiagonals.Contains(row - col) &&
                    !attakedRightDiagonals.Contains(row + col);
        }

        private static void PrintBoard(bool[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col])
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
