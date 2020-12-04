using System;

namespace _1._Easter_Cozonacs
{
    class Program
    {
        static void Main(string[] args)
        {
            double budjet = double.Parse(Console.ReadLine());
            double flourPrice = double.Parse(Console.ReadLine());
            int cozonakCount = 0;
            int colorEggs = 0;
            double eggsPrice = flourPrice * 0.75;
            double milkPrice = (flourPrice * 1.25) / 4;
            double cozonakPrice = flourPrice + eggsPrice + milkPrice;
            double moneyForCozonac = budjet;
            while (budjet > cozonakPrice)
            {
                budjet -= cozonakPrice;
                cozonakCount++;
                colorEggs += 3;

                if (cozonakCount % 3 == 0)
                {
                    colorEggs -= cozonakCount - 2;
                }
            }

            Console.WriteLine($"You made {cozonakCount} cozonacs! Now you have {colorEggs} eggs and {moneyForCozonac - cozonakPrice * cozonakCount:f2}BGN left.");
        }
    }
}
