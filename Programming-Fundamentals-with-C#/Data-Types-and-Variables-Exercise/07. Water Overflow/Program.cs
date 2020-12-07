using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int totalWater = 0;
            for (int i = 0; i < n; i++)
            {
                int quantities = int.Parse(Console.ReadLine());

                if (quantities > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }
                totalWater += quantities;

                if (totalWater  > 255)
                {
                    totalWater -= quantities;
                    Console.WriteLine("Insufficient capacity!");
                }

            }
            Console.WriteLine(totalWater);
        }
    }
}
