using System;

namespace _01._Convert_Meters_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());
            decimal km = meters * 0.001M;
            Console.WriteLine($"{km:F2}");
        }
    }
}
