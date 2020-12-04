using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices.ComTypes;

namespace _1._Computer_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceWithoutTaxes = 0;
            string command = Console.ReadLine();
            
            
            while (command != "special" && command != "regular")
            {
                double price = double.Parse(command);

                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                    command = Console.ReadLine();
                    continue;
                }

                priceWithoutTaxes += price;

                command = Console.ReadLine();
            }

            if (priceWithoutTaxes == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                double taxes = priceWithoutTaxes * 0.2;
                double priceWithTaxes = priceWithoutTaxes + taxes;

                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {priceWithoutTaxes:f2}$");
                Console.WriteLine($"Taxes: {taxes:f2}$");
                Console.WriteLine("-----------");

                if (command == "special")
                {
                    double totalPrice = priceWithTaxes * 0.9;
                    Console.WriteLine($"Total price: {totalPrice:f2}$");

                }
                else
                {
                    Console.WriteLine($"Total price: {priceWithTaxes:f2}$");
                }
            }
        }
    }
}
