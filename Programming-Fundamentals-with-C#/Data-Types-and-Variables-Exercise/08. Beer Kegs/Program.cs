using System;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            byte kegs = byte.Parse(Console.ReadLine());
            double biggestVolume = 0;
            string biggestKeg = string.Empty;

            for (int i = 0; i < kegs; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                double kegVolume = 0;

                kegVolume = Math.PI * Math.Pow(radius, 2) * height;

                if (kegVolume > biggestVolume)
                {
                    biggestVolume = kegVolume;
                    biggestKeg = model;
                }
            }

            Console.WriteLine(biggestKeg);
        }
    }
}
