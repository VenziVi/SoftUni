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
			
		}
	}
}