namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //int input = int.Parse(Console.ReadLine());

            //Console.WriteLine(IncreasePrices(db));
        }

        public static void IncreasePrices(BookShopContext context)
        {

            var books = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);
        
            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
 
        }
    }
}
