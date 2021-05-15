using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private readonly Dictionary<string, Item> items;

        //CHECK IF ERORR
        //private const int DefaultCapacity = 100;

        public Bag(int capacity)
        {
            this.Capacity = capacity;

            items = new Dictionary<string, Item>();
        }

        public int Capacity { get; set; }

        public int Load => this.Items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items => items.Values.ToList();

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(Constants.ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.items.Add(item.GetType().Name, item);
        }

        public Item GetItem(string name)
        {
            if (this.Items.Count == 0)
            {
                throw new InvalidOperationException(Constants.ExceptionMessages.EmptyBag);
            }

            if (!this.items.ContainsKey(name))
            {
                throw new ArgumentException(string.Format(Constants.ExceptionMessages.ItemNotFoundInBag, name));
            }

            Item item = items[name];
            items.Remove(name);
            return item;
        }
    }
}
