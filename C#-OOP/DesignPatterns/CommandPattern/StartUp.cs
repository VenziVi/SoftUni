using System;

namespace CommandPattern
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var modifyPrice = new ModifyPrice();
            var product = new Product("Toy", 50);


            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 10));
            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 10));
            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Decrease, 10));

            Console.WriteLine(product);
        }

        private static void Execute(Product product, ModifyPrice modifyPrice, ProductCommand productCommand)
        {
            modifyPrice.SetCommand(productCommand);
            modifyPrice.Invoke();
        }
    }
}
