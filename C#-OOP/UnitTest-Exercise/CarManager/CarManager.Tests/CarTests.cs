using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
            car = new Car("make", "model", 10, 60);
        }

        [Test]
        [TestCase("BMW", "318", 10, 60, 0)]
        public void WouldConstructorSetValuesProperly(
            string make, string model, double fuelConsumption, double fuelCapacity, double fuelAmount)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);


            Assert.AreEqual(car.Make, make);
            Assert.AreEqual(car.Model, model);
            Assert.AreEqual(car.FuelConsumption, fuelConsumption);
            Assert.AreEqual(car.FuelCapacity, fuelCapacity);
            Assert.AreEqual(car.FuelAmount, fuelAmount);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ShouldThrowExeptionIfMakeIsNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, "model", 10, 60));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ShouldThrowExeptionIfModelIsNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() => new Car("make", model, 10, 60));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void ShouldThrowExeptionIfFuelConsumptionIsNullOrNegative(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => new Car("make", "model", fuelConsumption, 60));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-60)]
        public void ShouldThrowExeptionIfFuelCapacityIsNullOrNegative(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car("make", "model", 10, fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-15)]
        public void RefuelThrowsExceptionWhenFuelToRefuelIsNullOrNegative(double fuel)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(fuel));
        }

        [Test]
        [TestCase(60)]
        [TestCase(65)]
        public void RefuelIncreaseFuelAmount(double fuel)
        {
            car.Refuel(fuel);

            var excpectedResult = 60;
            var actualResult = car.FuelAmount;

            Assert.AreEqual(excpectedResult, actualResult);
        }

        [Test]
        [TestCase(100)]
        public void DriveThrowsExceptionIfFuelIsNotEnought(double km)
        {
            Assert.Throws<InvalidOperationException>(() => car.Drive(km));
        }

        [Test]
        [TestCase(100)]
        public void DriveDecreaseFuelAmount(double km)
        {
            car.Refuel(60);
            car.Drive(km);

            var expectedResult = 50;
            var actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}