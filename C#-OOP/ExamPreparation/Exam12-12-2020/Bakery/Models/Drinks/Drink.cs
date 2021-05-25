using Bakery.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Drinks
{
    public abstract class Drink : IDrink
    {
        private string name;
        private int portion;
        private decimal price;
        private string brand;

        public Drink(string name, int portion, decimal price, string brand)
        {
            this.Name = name;
            this.Portion = portion;
            this.Price = price;
            this.Brand = brand;
        }

        public string Brand
        {
            get => this.brand;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidBrand);
                }

                this.brand = value;
            }
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidName);
                }

                this.name = value;
            }
        }

        public int Portion
        {
            get => this.portion;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidPortion);
                }

                this.portion = value;
            }
        }

        public decimal Price
        {
            get => this.price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidPrice);
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            return $"{this.name} {this.brand} - {this.portion}ml - {this.price:f2}lv";
        }
    }
}
