﻿using System;

namespace GenericBoxOfInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>();
                box.Value = input;
                Console.WriteLine(box.ToString());
            }
        }
    }
}
