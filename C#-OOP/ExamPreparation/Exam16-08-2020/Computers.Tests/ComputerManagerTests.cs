using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager computerManager;

        [SetUp]
        public void Setup()
        {
            computerManager = new ComputerManager();
        }


        [Test]
        public void ShouldThrowExceptionWhenComputerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.AddComputer(null));

        }

        [Test]
        public void AddComputerIncreseComputersCount()
        {
            Computer computer = new Computer("Dell", "nqkakav", 1200m);
            computerManager.AddComputer(computer);

            Assert.AreEqual(computerManager.Count, 1);
        }

        [Test]
        public void ShouldThrowExceptionWhenComputerExists()
        {
            Computer computer = new Computer("Dell", "nqkakav", 1200m);
            computerManager.AddComputer(computer);

            Exception ex = Assert.Throws<ArgumentException>(() => computerManager.AddComputer(computer));

            string message = "This computer already exists.";

            Assert.AreEqual(message, ex.Message);

        }

        [Test]
        public void GetCompShouldThrowException()
        {
            Computer computer = new Computer("Dell", "nqkakav", 1200m);
            computerManager.AddComputer(computer);

            Exception ex = Assert.Throws<ArgumentException>(() => computerManager.GetComputer("Asus", "nqkakav"));

            Assert.AreEqual("There is no computer with this manufacturer and model.", ex.Message);
        }


        [Test]
        public void CheckIfGetComputersByManufacturerReturnsNullWhenNoComputerWithThisManufacturer()
        {
            computerManager.AddComputer(new Computer("Apple", "Mac1", 12.4m));
            computerManager.AddComputer(new Computer("Apple", "Mac2", 122.4m));
            computerManager.AddComputer(new Computer("Apple", "Mac3", 121.4m));
            var listByManufacturer = computerManager.GetComputersByManufacturer("Dell");
            Assert.AreEqual(listByManufacturer.Count, 0);
        }

        [Test]
        public void RemoveMethodShouldThrowNullExceptionWhenModelIsNull()
        {
            this.computerManager.AddComputer(new Computer("Apple", "Mac1", 12.4m));

            Assert.Throws<ArgumentNullException>(() =>
            {
                this.computerManager.RemoveComputer("Apple", null);
            });
        }
    }
}