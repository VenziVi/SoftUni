namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var games = context
				.Genres
				.ToArray()
				.Where(g => genreNames.Contains(g.Name))
				.Select(g => new
				{
					Id = g.Id,
					Genre = g.Name,
					Games = g.Games.Select(d => new
					{
						Id = d.Id,
						Title = d.Name,
						Developer = d.Developer.Name,
						Tags = string.Join(", ", d.GameTags.Select(x => x.Tag.Name)),
						Players = d.Purchases.Count
					})
					.Where(g => g.Players > 0)
					.OrderByDescending(d => d.Players)
					.ThenBy(d => d.Id)
					.ToArray(),
					TotalPlayers = g.Games.Sum(g => g.Purchases.Count())
				})
				.OrderByDescending(g => g.TotalPlayers)
				.ThenBy(g => g.Id)
				.ToArray();

			var result = JsonConvert.SerializeObject(games, Formatting.Indented);

			return result;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			var users = context
				.Users
				.ToArray()
				.Select(u => new UsersExport
				{
					Username = u.Username,
					TotalSpent = u.Cards.SelectMany(c => c.Purchases.Where(p => p.Type == Enum.Parse<PurchaseType>(storeType)))
					.Sum(p => p.Game.Price),
					Purchases = u.Cards
					.SelectMany(p => p.Purchases.Where(p => p.Type == Enum.Parse<PurchaseType>(storeType)))
					.OrderBy(p => p.Date)
					.Select(p => new PurchasesExport
					{
						Card = p.Card.Number,
						Cvc = p.Card.Cvc,
						Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
						Game = new GameExport
						{
							Title = p.Game.Name,
							Genre = p.Game.Genre.Name,
							Price = p.Game.Price
						}
					})
					.ToArray()
				})
				.OrderByDescending(u => u.TotalSpent)
				.ThenBy(u => u.Username)
				.ToArray();

			users = users.Where(u => u.Purchases.Count() > 0).ToArray();

			var sb = new StringBuilder();
			using StringWriter writer = new StringWriter(sb);

			XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();

			namespaces.Add(string.Empty, string.Empty);

			XmlSerializer seriliazer = new XmlSerializer(typeof(UsersExport[]), new XmlRootAttribute("Users"));

			seriliazer.Serialize(writer, users, namespaces);

			return sb.ToString().TrimEnd();
		}
	}
}