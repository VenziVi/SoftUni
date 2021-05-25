using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                var splited = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (splited.Length != 5)
                {
                    Console.WriteLine("Invalid input!");               
                }
                else
                {
                    var cmdArg = splited[0];
                    var row1 = int.Parse(splited[1]);
                    var col1 = int.Parse(splited[2]);
                    var row2 = int.Parse(splited[3]);
                    var col2 = int.Parse(splited[4]);

                    if (cmdArg != "swap" || 
                          row1 > size[0] ||
                          col1 > size[1] || 
                          row2 > size[0] ||
                          col2 > size[1])
                    {
                        Console.WriteLine("Invalid input!");
                        
                    }
                    else
                    {
                        string firstValue = matrix[row1, col1];
                        string secondValue = matrix[row2, col2];
                        matrix[row1, col1] = secondValue;
                        matrix[row2, col2] = firstValue;

                        for (int row = 0; row < size[0]; row++)
                        {
                            for (int col = 0; col < size[1]; col++)
                            {
                                Console.Write(matrix[row, col] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                }

                command = Console.ReadLine();
            }
        }
    }
}
