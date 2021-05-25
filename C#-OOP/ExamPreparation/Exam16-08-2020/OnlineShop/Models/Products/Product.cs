﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products
{
    public abstract class Product : IProduct
    {
        private int id;
        private string manufacturer;
        private string model;
        private decimal price;
        private double overallPerformance;

        public Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            this.Id = id;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.OverallPerformance = overallPerformance;
        }

        public int Id 
        {
            get => this.id; 
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(Common.Constants.ExceptionMessages.InvalidProductId);
                }

                this.id = value;
            }
        }

        public string Manufacturer
        {
            get => this.manufacturer;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Common.Constants.ExceptionMessages.InvalidManufacturer);
                }

                this.manufacturer = value;
            }
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Common.Constants.ExceptionMessages.InvalidModel);
                }

                this.model = value;
            }
        }

        public virtual decimal Price
        {
            get => this.price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(Common.Constants.ExceptionMessages.InvalidPrice);
                }

                this.price = value;
            }
        }

        public virtual double OverallPerformance
        {
            get => this.overallPerformance;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(Common.Constants.ExceptionMessages.InvalidOverallPerformance);
                }

                this.overallPerformance = value;
            }
        }

        // check if error
        public override string ToString()
        {
            return $"Overall Performance: {this.overallPerformance:f2}. Price: {this.price:f2} - {this.GetType().Name}" +
                $": {this.manufacturer} {this.model} (Id: {this.id})";
        }
    }
}