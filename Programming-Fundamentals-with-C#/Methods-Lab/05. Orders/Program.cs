using System;

namespace _05._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            switch (product)
            {
                case "coffee":
                    coffee(quantity);
                    break;
                case "water":
                    water(quantity);
                    break;
                case "coke":
                    coke(quantity);
                    break;
                case "snacks":
                    snacks(quantity);
                    break;
            }
        }

        private static void coffee(int quantity)
        {
            Console.WriteLine($"{1.50 * quantity:f2}");

        }

        private static void water(int quantity)
        {
            Console.WriteLine($"{1.00 * quantity:f2}");
        }

        private static void coke(int quantity)
        {
            Console.WriteLine($"{1.40 * quantity:f2}");
        }

        private static void snacks(int quantity)
        {
            Console.WriteLine($"{2.00 * quantity:f2}");
        }
    }
}
