﻿using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            for (int i = 0; i < n; i++)
            {
                sum += matrix[0 + i, 0 + i];
            }

            Console.WriteLine(sum);
        }
    }
}
