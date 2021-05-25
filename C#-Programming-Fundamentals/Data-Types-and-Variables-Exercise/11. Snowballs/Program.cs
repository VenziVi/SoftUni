using System;
using System.Numerics;

namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            int currentSnowballSnow = 0;
            int currentSnowballTime = 0;
            int currentSnowballQuality = 0;
            BigInteger snowballValue = 0;

            for (int i = 0; i < n; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                int Snowball = snowballSnow / snowballTime;
                BigInteger currentSnowball = BigInteger.Pow(Snowball, snowballQuality);

                if (currentSnowball > snowballValue)
                {
                    snowballValue = currentSnowball;
                    currentSnowballSnow = snowballSnow;
                    currentSnowballTime = snowballTime;
                    currentSnowballQuality = snowballQuality;
                }
            }
            Console.WriteLine($"{currentSnowballSnow} : {currentSnowballTime} = {snowballValue} ({currentSnowballQuality})");
        }
    }
}
