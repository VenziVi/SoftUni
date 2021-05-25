using System;
using System.Collections.Generic;
using System.Text;

namespace Composite
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private List<GiftBase> _gifts;

        public CompositeGift(string name, int price) 
            : base(name, price)
        {
            _gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            _gifts.Add(gift);
        }

        public void Remove(GiftBase gift)
        {
            _gifts.Remove(gift);
        }

        public override int CalculateTotalPrice()
        {
            price = 0;

            Console.WriteLine($"{this.name} contains the following products with price:");

            foreach (var gift in _gifts)
            {
                price += gift.CalculateTotalPrice();
            }

            return price;
        }
    }
}
