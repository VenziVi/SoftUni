using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ConnectedAreasInMatrix
{
    internal class Area
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Size { get; set; }
    }

    internal class Program
    {
        private const char visitedSymbol = 'v';
        private static char[,] matrix;
        private static int areaSize = 0;
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            matrix = new Char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var input = Console.ReadLine();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            List<Area> areas = new List<Area>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    areaSize = 0;
                    Explore(i, j);

                    if (areaSize > 0)
                    {
                        areas.Add(new Area(){Row = i, Col = j, Size = areaSize});
                    }
                }
            }

            var storedAreas = areas
                .OrderByDescending(a => a.Size)
                .ThenBy(a => a.Row)
                .ThenBy(a => a.Col)
                .ToList();

            Console.WriteLine($"Total areas found: {storedAreas.Count}");

            for (int i = 0; i < areas.Count; i++)
            {
                Console.WriteLine($"Area #{i + 1} at ({storedAreas[i].Row}, {storedAreas[i].Col}), size: {storedAreas[i].Size}");
            }
        }

        private static void Explore(int row, int col)
        {
            if (isOutside(row, col) || isWall(row, col) || isVisited(row, col))
            {
                return;
            }

            areaSize += 1;
            matrix[row, col] = visitedSymbol;

            Explore(row + 1, col);
            Explore(row - 1, col);
            Explore(row, col + 1);
            Explore(row, col - 1);

        }

        private static bool isVisited(int row, int col)
        {
            return matrix[row, col] == visitedSymbol;
        }

        private static bool isOutside(int row, int col)
        {
            return row < 0 || 
                   col < 0 || 
                   row >= matrix.GetLength(0) || 
                   col >= matrix.GetLength(1);
        }

        private static bool isWall(int row, int col)
        {
            return matrix[row, col] == '*';
        }
    }
}
