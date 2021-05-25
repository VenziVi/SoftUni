using System;
using System.Data.SqlTypes;

namespace _1._Disneyland_Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double jurneyCost = double.Parse(Console.ReadLine());
            int mounts = int.Parse(Console.ReadLine());
            double moneySavedforMounth = jurneyCost * 0.25;
            double moneySaved = 0.0;

            for (int i = 1; i <= mounts; i++)
            {

                if (i % 2 == 1 && i != 1)
                {
                    moneySaved -= moneySaved * 0.16;
                }


                if (i % 4 == 0)
                {
                    moneySaved += moneySaved * 0.25;
                }

                moneySaved += moneySavedforMounth;
            }

            if (moneySaved >= jurneyCost)
            {
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {moneySaved - jurneyCost:f2}lv. for souvenirs.");
            }
            else
            {
                Console.WriteLine($"Sorry. You need {jurneyCost - moneySaved:f2}lv. more.");
            }
        }
    }
}
