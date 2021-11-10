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

            Console.WriteLine(GetGoldenBooks(db));
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();


            var goldenBooks = context
                .Books
                .Where(b =>b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(B => B.BookId)
                .Select(b => b.Title)
                .ToArray();

            foreach (var title in goldenBooks)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
