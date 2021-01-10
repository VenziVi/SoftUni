using System;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string coins = Console.ReadLine();
            double coinsAdded = 0;

            while (coins != "Start")
            {
                double money = double.Parse(coins);
                bool validCoins = money == 0.1 ||
                                  money == 0.2 ||
                                  money == 0.5 ||
                                  money == 1 ||
                                  money == 2;

                if (validCoins)
                {
                    coinsAdded += money;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {money}");
                }
                coins = Console.ReadLine();
            }
            string product = Console.ReadLine();
            while (product != "End")
            {
                bool validProduct = true;
                double productPrice = 0;

                if (product == "Nuts")
                {
                    productPrice = 2;
                }
                else if (product == "Water")
                {
                    productPrice = 0.7;
                }
                else if (product == "Crisps")
                {
                    productPrice = 1.5;
                }
                else if (product == "Soda")
                {
                    productPrice = 0.8;
                }
                else if (product == "Coke")
                {
                    productPrice = 1;
                }
                else
                {
                    validProduct = false;
                    Console.WriteLine("Invalid product");
                }

                if (productPrice <= coinsAdded && validProduct)
                {
                    coinsAdded -= productPrice;
                    Console.WriteLine($"Purchased {product.ToLower()}");
                }
                else if (productPrice > coinsAdded && validProduct)
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                product = Console.ReadLine();
            }

            Console.WriteLine($"Change: {coinsAdded:f2}");
        }
    }
}
