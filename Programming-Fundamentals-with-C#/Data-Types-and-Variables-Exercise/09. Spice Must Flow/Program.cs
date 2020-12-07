using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            byte days = 0;
            int totalSpice = 0;

            while (yield >= 100)
            {
                totalSpice += yield - 26;
                days++;

                yield -= 10;
            }
            
            if (totalSpice >= 26)
            {
                totalSpice -= 26;
            }
            Console.WriteLine(days);
            Console.WriteLine(totalSpice);
        }
    }
}
