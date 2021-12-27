namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			var sb = new StringBuilder();

			var gamesDto = JsonConvert.DeserializeObject<GameImportDto[]>(jsonString);

			var gameList = new HashSet<Game>();

            foreach (var game in gamesDto)
            {
                if (!IsValid(game))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				bool isValidDate = DateTime.TryParseExact(game.ReleaseDate, "yyyy-MM-dd", 
					CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate);

                if (!isValidDate)
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

                if (game.Tags.Count() == 0)
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				Developer gameDeveloper = context.Developers.FirstOrDefault(d => d.Name == game.Developer);

                if (gameDeveloper == null)
                {
					gameDeveloper = new Developer
					{
						Name = game.Developer
					};
                }

				Genre gameGenre = context.Genres.FirstOrDefault(g => g.Name == game.Genre);

                if (gameGenre == null)
                {
					gameGenre = new Genre { Name = game.Genre };
                }

				Game g = new Game
				{
					Name = game.Name,
					Price = game.Price,
					ReleaseDate = parsedDate,
					Developer = gameDeveloper,
					Genre = gameGenre
				};

				foreach (var tag in game.Tags)
				{
					var currTag = context.Tags.FirstOrDefault(t => t.Name == tag);
                    if (currTag == null)
                    {
						currTag = new Tag { Name = tag };
                    }

					var gameTag = g.GameTags.FirstOrDefault(gt => gt.Tag.Name == tag);
                    if (gameTag == null)
                    {
						gameTag = new GameTag { Tag = currTag };
                    }

					g.GameTags.Add(gameTag);
				}

				context.Games.Add(g);
				context.SaveChanges();
				sb.AppendLine($"Added {g.Name} ({g.Genre.Name}) with {g.GameTags.Count} tags");
			}

			return sb.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			var sb = new StringBuilder();

			var usersDto = JsonConvert.DeserializeObject<UserImportDto[]>(jsonString);

			var userList = new HashSet<User>();

            foreach (var userDto in usersDto)
            {
                if (!IsValid(userDto) || !userDto.Cards.All(IsValid))
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				User u = new User
				{
					Username = userDto.Username,
					FullName = userDto.FullName,
					Email = userDto.Email,
					Age = userDto.Age
				};

				var userCards = new HashSet<Card>();

                foreach (var card in userDto.Cards)
                {
					Card c = new Card
					{
						Number = card.Number,
						Cvc = card.CVC,
						Type = Enum.Parse<CardType>(card.Type)
					};

					userCards.Add(c);
                }

				u.Cards = userCards;
				userList.Add(u);
				sb.AppendLine($"Imported {u.Username} with {u.Cards.Count} cards");
			}

			context.Users.AddRange(userList);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			var sb = new StringBuilder();

			using StringReader reader = new StringReader(xmlString);

			XmlSerializer serializer = new XmlSerializer(typeof(PurchiseImportDto[]), new XmlRootAttribute("Purchases"));

			PurchiseImportDto[] dtos = (PurchiseImportDto[])serializer.Deserialize(reader);

			var purchises = new HashSet<Purchase>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				bool isDateValid = DateTime.TryParseExact(dto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture,
					DateTimeStyles.None, out DateTime currDate);

				Card card = context.Cards.FirstOrDefault(c => c.Number == dto.Card);

				User user = context.Users.FirstOrDefault(u => u.Cards.Any(c => c.Number == card.Number));

				Game game = context.Games.FirstOrDefault(g => g.Name == dto.Title);

				if (!isDateValid || card == null || game == null)
				{
					sb.AppendLine("Invalid Data");
					continue;
				}

				Purchase p = new Purchase
				{
					Type = Enum.Parse<PurchaseType>(dto.Type),
					ProductKey = dto.Key,
					Game = game,
					Date = currDate,
					Card = card
				};

				purchises.Add(p);
				sb.AppendLine($"Imported {dto.Title} for {user.Username}");
            }

			context.Purchases.AddRange(purchises);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}