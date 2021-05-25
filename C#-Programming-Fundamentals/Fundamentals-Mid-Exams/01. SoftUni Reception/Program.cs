using System;

namespace _01._SoftUni_Reception
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            int hoursCount = 0;
            int answer = first + second + third;

            while (students > 0)
            {
                students -= answer;
                hoursCount++;

                if (hoursCount % 4 == 0)
                {
                    hoursCount++;
                }

            }
            Console.WriteLine($"Time needed: {hoursCount}h.");
        }
    }
}
