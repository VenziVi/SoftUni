using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        public List<Product> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }

        public string Name 
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public decimal Money 
        {
            get => this.money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }
        public IReadOnlyCollection<Product> Products
        {
            get
            {
                return this.products;
            }
        }

        public void AddProduct(Person person, Product product)
        {
            if (CanBuyProduct(person, product))
            {
                person.products.Add(product);
                Console.WriteLine($"{person.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{person.Name} can't afford {product.Name}");
            }
        }

        private bool CanBuyProduct(Person person, Product product)
        {
            if (person.Money >= product.Cost)
            {
                person.Money -= product.Cost;
                return true;
            }
            return false;
        }

    }
}
