// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
	public class StageTests
    {
		[Test]
	    public void AddPerformerThrowExceptionWhenAgeBelowEighteen()
	    {
			Stage stage = new Stage();
			Performer performer = new Performer("name", "lastName", 10);

			Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer));
		}

		[Test]
		public void CreatePerformer()
        {
			Performer performer = new Performer("name", "lastName", 19);

			Assert.AreEqual(performer.FullName, "name" + " " + "lastName");
			Assert.AreEqual(performer.Age, 19);
		}

		[Test]
		public void AddPerformer()
        {
			List<Performer> performers = new List<Performer>();
			Performer performer = new Performer("name", "lastName", 19);

			performers.Add(performer);

			Assert.AreEqual(performers.Count, 1);
		}

		[Test]
		public void AddSongThrowsException()
        {
			Stage stage = new Stage();
			Song song = new Song("name", new TimeSpan(0,0,50));
			

			Assert.Throws<ArgumentException>(() => stage.AddSong(song));
		}	
		
		[Test]
		public void AddPerformerWithNullValue()
        {
			Stage stage = new Stage();

			Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null));
        }

		[Test]
		public void AddSongWithNullValue()
		{
			Stage stage = new Stage();

			Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));
		}

		[Test]
		public void AddSongToPerformerList()
		{
			Stage stage = new Stage();
			Song song = new Song("nameS", new TimeSpan(0, 3, 50));
			Performer performer = new Performer("name", "lastName", 19);
			stage.AddPerformer(performer);
			stage.AddSong(song);

			stage.AddSongToPerformer("nameS", "name" + " " + "lastName");

			int songCount = performer.SongList.Count();

			Assert.AreEqual(songCount, 1);
		}

		[Test]
		public void AddSongToPerformerListText()
		{
			Stage stage = new Stage();
			Song song = new Song("nameS", new TimeSpan(0, 3, 50));
			Performer performer = new Performer("name", "lastName", 19);
			stage.AddPerformer(performer);
			stage.AddSong(song);

			string result = stage.AddSongToPerformer("nameS", "name" + " " + "lastName");

			Assert.AreEqual("nameS (03:50) will be performed by name lastName", result);
		}

		[Test]
		public void GetPerformer()
		{
			Stage stage = new Stage();
			Song song = new Song("nameS", new TimeSpan(0, 3, 50));
			stage.AddSong(song);

			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("nameS", "name" + " " + "lastName"));
		}


		[Test]
		public void GetSong()
		{
			Stage stage = new Stage();
			Performer performer = new Performer("name", "lastName", 19);
			stage.AddPerformer(performer);

			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("nameS", "name" + " " + "lastName"));
		}

		[Test]
		public void PlayMethod()
        {
			Stage stage = new Stage();
			Song song = new Song("nameS", new TimeSpan(0, 3, 50));
			Performer performer = new Performer("name", "lastName", 19);
			stage.AddPerformer(performer);
			stage.AddSong(song);
			stage.AddSongToPerformer("nameS", "name" + " " + "lastName");

			Assert.AreEqual("1 performers played 1 songs", stage.Play()); ;
		}

	}
}