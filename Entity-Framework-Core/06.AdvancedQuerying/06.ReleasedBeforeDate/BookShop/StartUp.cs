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

            Console.WriteLine(GetBooksReleasedBefore(db, "30-12-1989"));
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            string[] input = date.Split('-', StringSplitOptions.RemoveEmptyEntries).ToArray();

            var dd = int.Parse(input[0]);
            var mm = int.Parse(input[1]);
            var yyyy = int.Parse(input[2]);

            DateTime currDate = new DateTime(yyyy, mm, dd);

            var books = context
                .Books
                .Where(b => b.ReleaseDate < currDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new { Title = b.Title, Edition = b.EditionType, Price = b.Price})
                .ToArray();
                
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.Edition} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
