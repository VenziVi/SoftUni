using System;
using System.Collections.Generic;

namespace TupleCr
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split();
            string firstName = $"{text[0]} {text[1]}";
            string secondName = text[2];

            Tuple1<string, string> tuple = new Tuple1<string, string>(firstName, text[2]);
            Console.WriteLine($"{tuple.Item1} -> {tuple.Item2}");

            string[] text1 = Console.ReadLine().Split();
            string name = text1[0];
            int liters = int.Parse(text1[1]);

            Tuple1<string, int> tuple1 = new Tuple1<string, int>(name, liters);
            Console.WriteLine($"{tuple1.Item1} -> {tuple1.Item2}");

            string[] text2 = Console.ReadLine().Split();
            int num = int.Parse(text2[0]);
            double secNum = double.Parse(text2[1]);

            Tuple1<int, double> tuple2 = new Tuple1<int, double>(num, secNum);
            Console.WriteLine($"{tuple2.Item1} -> {tuple2.Item2}");

        }
    }
}
