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

            string input = Console.ReadLine();

            Console.WriteLine(GetAuthorNamesEndingIn(db, input));
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();


            var authors = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input.ToLower()))
                .Select(a => a.FirstName + " " + a.LastName)
                .OrderBy(a => a)
                .ToArray();
                
            foreach (var author in authors)
            {
                sb.AppendLine(author);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
