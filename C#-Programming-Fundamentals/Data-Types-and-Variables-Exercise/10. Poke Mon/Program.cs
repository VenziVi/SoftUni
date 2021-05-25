using System;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            int targetCounter = 0;
            double power = pokePower * 0.5;

            while (pokePower >= distance)
            {
                pokePower -= distance;
                targetCounter++;

                if (pokePower == power && exhaustionFactor != 0)
                {
                    pokePower /= exhaustionFactor;  
                }
            }
            Console.WriteLine($"{pokePower} \n{targetCounter}");
        }
    }
}
