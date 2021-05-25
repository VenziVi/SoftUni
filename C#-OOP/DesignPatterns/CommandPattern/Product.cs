using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
    public class Product
    {
        public Product(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }

        public int Price { get; set; }

        public void IncreasePrice(int amount)
        {
            this.Price += amount;
            Console.WriteLine($"The price for the {this.Name} has been increased by {amount}$.");
        }

        public void DecreasePrice(int amount)
        {
            this.Price -= amount;
            Console.WriteLine($"The price for the {this.Name} has been decreased by {amount}$.");
        }

        public override string ToString()
        {
            return $"Current price fpr the {this.Name} product is {this.Price}$.";
        }
    }
}
