using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07._Store_Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] cmdArgs = line.Split();
                decimal priceForBox = int.Parse(cmdArgs[2]) * decimal.Parse(cmdArgs[3]);

                
                Box box = new Box(cmdArgs[0], new Item(cmdArgs[1], decimal.Parse(cmdArgs[3])), int.Parse(cmdArgs[2]), priceForBox);
                box.Item = new Item(cmdArgs[1], decimal.Parse(cmdArgs[3]));
                boxes.Add(box);

                line = Console.ReadLine();
            }
            boxes = boxes.OrderByDescending(x => x.PriceForBox).ToList();
            foreach (var box in boxes)
            {
                Console.WriteLine(box);
            }
        }
    }


    class Box
    {
        public Box(string serialNumber, Item item, int itemQuantity, decimal priceForBox)
        {
            SerialNumber = serialNumber;
            Item = new Item();
            ItemQuantity = itemQuantity;
            PriceForBox = priceForBox;
        }

        public string SerialNumber { get; set; }

        public Item Item { get; set; }

        public int ItemQuantity { get; set; }

        public decimal PriceForBox { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(SerialNumber);
            sb.AppendLine($"-- {Item.Name} - ${Item.Price:f2}: {ItemQuantity}");
            sb.AppendLine($"-- ${PriceForBox:f2}");
            return sb.ToString().TrimEnd();
        }
    }

    class Item
    {
        public Item()
        {
        }

        public Item(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
