namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(PlaysImportDto[]), new XmlRootAttribute("Plays"));

            using StringReader reader = new StringReader(xmlString);

            PlaysImportDto[] dtos = (PlaysImportDto[])serializer.Deserialize(reader);

            var playsList = new HashSet<Play>();

            foreach (var dto in dtos)
            {
                string[] genres = new string[] { "Drama", "Comedy", "Romance", "Musical"};

                bool isDurationValid = TimeSpan.TryParseExact(dto.Duration, "c", CultureInfo.InvariantCulture,
                    TimeSpanStyles.None, out TimeSpan currDuration);

                TimeSpan needeDuration = new TimeSpan(1, 00, 00);

                if (!IsValid(dto) || !genres.Contains(dto.Genre) || !isDurationValid || currDuration < needeDuration)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                Play currPlay = new Play()
                {
                    Title = dto.Title,
                    Duration = currDuration,
                    Rating = dto.Rating,
                    Genre = Enum.Parse<Genre>(dto.Genre),
                    Description = dto.Description,
                    Screenwriter = dto.Screenwriter
                };

                playsList.Add(currPlay);
                sb.AppendLine($"Successfully imported {dto.Title} with genre {dto.Genre} and a rating of {dto.Rating}!");
            }

            context.Plays.AddRange(playsList);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(CastsImportDto[]), new XmlRootAttribute("Casts"));

            using StringReader reader = new StringReader(xmlString);

            CastsImportDto[] dtos = (CastsImportDto[])serializer.Deserialize(reader);

            var castsList = new HashSet<Cast>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto) || (dto.IsMainCharacter != "true" && dto.IsMainCharacter != "false"))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                Cast cast = new Cast()
                {
                    FullName = dto.FullName,
                    IsMainCharacter = bool.Parse(dto.IsMainCharacter),
                    PhoneNumber = dto.PhoneNumber,
                    PlayId = dto.PlayId
                };

                var mainCharacter = cast.IsMainCharacter == true ? "main" : "lesser";

                castsList.Add(cast);
                sb.AppendLine($"Successfully imported actor {dto.FullName} as a {mainCharacter} character!");
            }

            context.Casts.AddRange(castsList);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
