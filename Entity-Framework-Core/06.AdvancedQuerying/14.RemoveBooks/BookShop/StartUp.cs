namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Text;
    using Z.EntityFramework.Plus;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //int input = int.Parse(Console.ReadLine());

            //Console.WriteLine(IncreasePrices(db));
        }

        public static int RemoveBooks(BookShopContext context)
        {

            var books = context
                .Books
                .Where(b => b.Copies < 4200)
                .Delete();

            return books;
 
        }
    }
}
