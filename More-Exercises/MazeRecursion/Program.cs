using System;

namespace MazeRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] maze = new string[]
            {
                "010001",
                "01010E",
                "010100",
                "000000"
            };
            PrintMaze(maze);
            Console.WriteLine("----------------");
            findPaths(maze, 0, 0, new bool[maze.Length, maze[0].Length], "");
        }

        private static void findPaths(string[] maze, int row, int col, bool[,] visited, string path)
        {
            if (maze[row][col] == 'E')
            {
                Console.WriteLine(path);
                return;
            }

            visited[row, col] = true;

            if (IsValid(maze, row + 1, col, visited))
            {
                findPaths(maze, row + 1, col, visited, path + "D");
            }
            if (IsValid(maze, row - 1, col, visited))
            {
                findPaths(maze, row - 1, col, visited, path + "U");
            }
            if (IsValid(maze, row, col + 1, visited))
            {
                findPaths(maze, row, col + 1, visited, path + "R");
            }
            if (IsValid(maze, row, col - 1, visited))
            {
                findPaths(maze, row, col - 1, visited, path + "L");
            }

            visited[row, col] = false;
        }

        private static bool IsValid(string[] maze, int row, int col, bool[,] visited)
        {
            if (row < 0 || col < 0 || row >= maze.Length || col >= maze[0].Length)
            {
                return false;
            }
            if (visited[row, col] || maze[row][col] == '1')
            {
                return false;
            }

            return true;
        }

        private static void PrintMaze(string[] maze)
        {
            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze[0].Length; col++)
                {
                    Console.Write(maze[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
