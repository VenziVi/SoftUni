using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] splited = command.Split();
                var row = int.Parse(splited[1]);
                var col = int.Parse(splited[2]);
                var value = int.Parse(splited[3]);

                if (row < 0 || col < 0 ||
                    row >= matrix.GetLength(0) || 
                    col >= matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else if (splited[0] == "Add")
                {
                    matrix[row, col] += value;
                }
                else if (splited[0] == "Subtract")
                {
                    matrix[row, col] -= value;
                }

                command = Console.ReadLine();
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
