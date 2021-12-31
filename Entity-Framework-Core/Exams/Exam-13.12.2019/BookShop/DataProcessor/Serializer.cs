namespace BookShop.DataProcessor
{
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context
                .Authors
                .Select(a => new
                {
                    AuthorName = $"{a.FirstName} {a.LastName}",
                    Books = a.AuthorsBooks
                   .Select(b => b.Book)
                   .OrderByDescending(b => b.Price)
                   .Select(b => new 
                    {
                        BookName = b.Name,
                        BookPrice = b.Price.ToString("f2")

                    })
                    .ToArray()
                })
                .ToArray()
                .OrderByDescending(a => a.Books.Count())
                .ThenBy(a => a.AuthorName)
                .ToArray();

            var result = JsonConvert.SerializeObject(authors, Formatting.Indented);

            return result;
           
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
           
        }
    }
}