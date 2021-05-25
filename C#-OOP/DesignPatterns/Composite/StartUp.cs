using System;

namespace Composite
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var phone = new SingleGift("motorola", 250);
            phone.CalculateTotalPrice();
            Console.WriteLine("---------------------------------");

            var box = new CompositeGift("BOX", 0);
            var watch = new SingleGift("Rolex", 320);
            var ring = new SingleGift("GoldRing", 500);

            box.Add(watch);
            box.Add(ring);

            var smallBox = new CompositeGift("SmallBox", 0);
            var neshoMalko = new SingleGift("minion", 110);

            smallBox.Add(neshoMalko);
            box.Add(smallBox);
            Console.WriteLine($"Total gift Price is {box.CalculateTotalPrice()}");
        }
    }
}
