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


        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            string[] categories = input.Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToLower()).ToArray();

            var books = context
                .Books
                .Where(b => b.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();
                
            foreach (var title in books)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
