using System;

namespace _1._National_Court
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployee = int.Parse(Console.ReadLine());
            int secondEmployee = int.Parse(Console.ReadLine());
            int thirdEmployee = int.Parse(Console.ReadLine());
            int peopleCount = int.Parse(Console.ReadLine());
            int peopleLeft = peopleCount;
            int hourCount = 0;
            int helpPerHour = firstEmployee + secondEmployee + thirdEmployee;

            while (peopleLeft > 0)
            {
                peopleLeft -= helpPerHour;
                hourCount++;

                if (hourCount % 4 == 0)
                {
                    hourCount++;
                }

            }           
            Console.WriteLine($"Time needed: {hourCount}h.");
        }
    }
}
