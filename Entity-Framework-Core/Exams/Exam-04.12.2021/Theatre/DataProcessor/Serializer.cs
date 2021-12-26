namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
		var theatres = context
                .Theatres
                .ToArray()
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count() >= 20)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = decimal.Parse(t.Tickets
                    .Where(x => x.RowNumber >= 1 && x.RowNumber <= 5)
                    .Sum(t => t.Price).ToString("f2")),
                    Tickets = t.Tickets.Where(x => x.RowNumber >= 1 && x.RowNumber <= 5).Select(c => new
                    {
                        Price = decimal.Parse(c.Price.ToString("f2")),
                        RowNumber = c.RowNumber
                    })
                    .OrderByDescending(c => c.Price)
                    .ToArray()
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();

            var result = JsonConvert.SerializeObject(theatres, Formatting.Indented);

            return result.ToString().TrimEnd();
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var sb = new StringBuilder();

            using StringWriter writer = new StringWriter(sb);

            XmlSerializer serializer = new XmlSerializer(typeof(PlaysExportDto[]), new XmlRootAttribute("Plays"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var plays = context
                .Plays
                .ToArray()
                .Where(p => p.Rating <= rating)
                .OrderBy(p => p.Title)
                .Select(p => new PlaysExportDto
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c", CultureInfo.InvariantCulture),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts.Where(p => p.IsMainCharacter == true)
                    .Select(a => new ActorsExportDto
                    {
                        FullName = a.FullName,
                        MainCharacter = $"Plays main character in '{a.Play.Title}'."
                    })
                    .OrderByDescending(a => a.FullName)
                    .ToArray()
                })
                .ToArray();

            serializer.Serialize(writer, plays, namespaces);

            return writer.ToString().TrimEnd();
        }
    }
}
