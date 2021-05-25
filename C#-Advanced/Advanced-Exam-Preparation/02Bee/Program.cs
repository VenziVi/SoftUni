using System;

namespace _02Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int beeRow = -1;
            int beeCol = -1;
            int flowers = 0;

            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                matrix[beeRow, beeCol] = '.';

                beeRow = MoveRow(beeRow, command);
                beeCol = MoveCol(beeCol, command);

                if (!IsInField(beeRow , beeCol, n, n))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (matrix[beeRow, beeCol] == 'O')
                {
                    matrix[beeRow, beeCol] = '.';

                    beeRow = MoveRow(beeRow, command);
                    beeCol = MoveCol(beeCol, command);

                    if (!IsInField(beeRow, beeCol, n, n))
                    {
                        Console.WriteLine("The bee got lost!");
                        return;
                    }
                }

                if (matrix[beeRow, beeCol] == 'f')
                {
                    flowers++;
                }

                matrix[beeRow, beeCol] = 'B';

                command = Console.ReadLine();
            }

            if (flowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowers} flowers more");
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static int MoveCol(int beeCol, string command)
        {
            if (command == "left")
            {
                beeCol -= 1;
            }
            if (command == "right")
            {
                beeCol += 1;
            }

            return beeCol;
        }

        private static int MoveRow(int beeRow, string command)
        {
            if (command == "up")
            {
                beeRow -= 1;
            }
            if (command == "down")
            {
                beeRow += 1;
            }

            return beeRow;
        }

        private static bool IsInField(int beeRow, int beeCol, int rows, int cols)
        {
            if (beeRow < 0 || beeRow >= rows)
            {
                return false;
            }
            if (beeCol < 0 || beeCol >= cols)
            {
                return false;
            }

            return true;
        }
    }
}
