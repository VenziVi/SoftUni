
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            database = new ExtendedDatabase();
        }

        [Test]
        public void AddShouldThrowExceptionWhenCountExceeded()
        {
            int n = 16;
            
            for (int i = 0; i < n; i++)
            {
                database.Add(new Person(i, $"username{i}"));
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(122, "Ivan")));
        }

        [Test]
        public void AddShouldThrowExceptionWhenUserExsist()
        {
            int n = 10;

            for (int i = 0; i < n; i++)
            {
                database.Add(new Person(i, $"username{i}"));
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(15, "username9")));
        }

        [Test]
        public void AddShouldThrowExceptionWhenIdExsist()
        {
            int n = 10;

            for (int i = 0; i < n; i++)
            {
                database.Add(new Person(i, $"username{i}"));
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(9, "username55")));
        }

        [Test]
        public void AddShouldincreaseCount()
        {
            int n = 10;

            for (int i = 0; i < n; i++)
            {
                database.Add(new Person(i, $"username{i}"));
            }

            database.Add(new Person(22, "username55"));

            Assert.That(database.Count, Is.EqualTo(n + 1));
        }

        [Test]
        public void RemoveShouldThrowExeptionIfColectionIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void RemoveShouldDecreaseCount()
        {
            database.Add(new Person(22, "Ivan"));
            database.Add(new Person(20, "Stoyan"));

            database.Remove();

            int expectedResult = 1;
            int actualResult = database.Count;

            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsernameShouldThrowExceptionIfNameIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(name));
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionIfNameDosentExsist()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("name"));
        }

        [Test]
        public void FindByUsernameShouldFindPersonWithName()
        {
            Person person = new Person(1, "Nasko");
            database.Add(person);

            Person findedPerson = database.FindByUsername("Nasko");

            Assert.AreEqual(person, findedPerson);
        }

        [Test]
        [TestCase(-5)]
        public void FindByIdShouldThrowExceptionWhenIdIsLessThanZero(int id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(id));
        }

        [Test]
        public void FindByIdShouldThrowExceptionWhenIdIsMissing()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindById(1));
        }

        [Test]
        public void FindByIdShouldFindPersonWithId()
        {
            Person person = new Person(1, "Nasko");
            database.Add(person);

            Person findedPerson = database.FindById(1);

            Assert.AreEqual(person, findedPerson);
        }

    }
}