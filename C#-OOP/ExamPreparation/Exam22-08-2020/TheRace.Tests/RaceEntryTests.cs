using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ExceptionDriverIsNull()
        {
            RaceEntry race = new RaceEntry();
            //UnitCar car = new UnitCar("a", 100, 3000);
            //UnitDriver driver = new UnitDriver("", car);

            Assert.Throws<InvalidOperationException>(() => race.AddDriver(null));
        }

        [Test]
        public void ExceptionDriverExists()
        {
            RaceEntry race = new RaceEntry();
            UnitCar car = new UnitCar("a", 100, 3000);
            UnitDriver driver = new UnitDriver("joro", car);
            race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => race.AddDriver(driver));
        }

        [Test]
        public void AddDriver()
        {
            RaceEntry race = new RaceEntry();
            UnitCar car = new UnitCar("a", 100, 3000);
            UnitDriver driver = new UnitDriver("joro", car);
            race.AddDriver(driver);

            Assert.AreEqual(race.Counter, 1);
        }

        [Test]
        public void LessThanMinParticipans()
        {
            RaceEntry race = new RaceEntry();
            UnitCar car = new UnitCar("a", 100, 3000);
            UnitDriver driver = new UnitDriver("joro", car);
            race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());
        }

        [Test]
        public void AverageHP()
        {
            RaceEntry race = new RaceEntry();
            UnitCar car = new UnitCar("a", 100, 3000);
            UnitCar car1 = new UnitCar("ab", 100, 3000);
            UnitCar car2 = new UnitCar("ac", 100, 3000);
            UnitDriver driver = new UnitDriver("joro", car);
            UnitDriver driver1 = new UnitDriver("joro1", car1);
            UnitDriver driver2 = new UnitDriver("joro3", car2);
            race.AddDriver(driver);
            race.AddDriver(driver1);
            race.AddDriver(driver2);

            Assert.AreEqual(race.CalculateAverageHorsePower(), 100);
        }
    }
}