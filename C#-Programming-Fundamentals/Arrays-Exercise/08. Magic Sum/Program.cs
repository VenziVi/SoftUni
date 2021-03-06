﻿using System;
using System.Linq;

namespace _08._Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                                .Split(" ")
                                .Select(int.Parse)
                                .ToArray();
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < arr.Length; i++)
            {
                int currentInt = arr[i];

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (currentInt + arr[j] == num)
                    {
                        Console.WriteLine($"{currentInt} {arr[j]}");
                        break;
                    }
                }
            }
        }
    }
}
