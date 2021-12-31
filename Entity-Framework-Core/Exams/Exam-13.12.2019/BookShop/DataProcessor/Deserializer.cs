namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";
        private static IFormatProvider cultureInfo;

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var sb = new StringBuilder();
            using StringReader reader = new StringReader(xmlString);

            XmlSerializer serializer = new XmlSerializer(typeof(BooksImportDto[]), new XmlRootAttribute("Books"));
            BooksImportDto[] books = (BooksImportDto[])serializer.Deserialize(reader);

            var bookList = new List<Book>();

            foreach (BooksImportDto book in books)
            {
                bool isDateValid = DateTime.TryParseExact(book.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime publishedDate);

                if (!IsValid(book) || !isDateValid)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                Book currBook = new Book()
                {
                    Name = book.Name,
                    Genre = (Genre)book.Genre,
                    Price = book.Price,
                    Pages = book.Pages,
                    PublishedOn = publishedDate,
                };

                bookList.Add(currBook);
                sb.AppendLine($"Successfully imported book {book.Name} for {book.Price:f2}.");
            }

            context.Books.AddRange(bookList);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}