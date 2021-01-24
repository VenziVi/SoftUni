using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] jagged = new double[n][];

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                jagged[i] = new double[input.Length];

                for (int j = 0; j < input.Length; j++)
                {
                    jagged[i][j] = input[j];
                }
            }

            for (int i = 0; i < n - 1; i++)
            {
                if (jagged[i].Length == jagged[i + 1].Length)
                {
                    for (int j = 0; j < jagged[i].Length; j++)
                    {
                        jagged[i][j] *= 2;
                    }
                    for (int k = 0; k < jagged[i + 1].Length; k++)
                    {
                        jagged[i + 1][k] *= 2;
                    }
                }
                else if (jagged[i].Length != jagged[i + 1].Length)
                {
                    for (int j = 0; j < jagged[i].Length; j++)
                    {
                        jagged[i][j] /= 2;
                    }
                    for (int k = 0; k < jagged[i + 1].Length; k++)
                    {
                        jagged[i + 1][k] /= 2;
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                var splited = command.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                var cmdArg = splited[0];
                var row = int.Parse(splited[1]);
                var col = int.Parse(splited[2]);
                var value = int.Parse(splited[3]);

                if (cmdArg == "Add")
                {
                    if (row >= 0 && row < n && col >= 0 && col < jagged[row].Length)
                    {
                        jagged[row][col] += value;
                    }
                }
                else if (cmdArg == "Subtract")
                {
                    if (row >= 0 && row < n && col >= 0 && col < jagged[row].Length)
                    {
                        jagged[row][col] -= value;
                    }
                }

                command = Console.ReadLine();
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write(jagged[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
