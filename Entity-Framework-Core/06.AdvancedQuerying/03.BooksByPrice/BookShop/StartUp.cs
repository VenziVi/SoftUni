namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetBooksByPrice(db));
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();


            var booksByPrice = context
                .Books
                .Where(b => b.Price > 40)
                .Select(b => new {title = b.Title, price = b.Price})
                .OrderByDescending(B => B.price)
                .ToArray();

            foreach (var book in booksByPrice)
            {
                sb.AppendLine($"{book.title} - ${book.price:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
