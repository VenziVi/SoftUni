using NUnit.Framework;
using System;

namespace Aquariums.Tests
{

    public class AquariumsTests
    {
        [Test]
        public void CreateName()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium("", 5));
        }

        [Test]
        public void CreateNameCapacity()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Devil", -5));
        }

        [Test]
        public void NoCapacity()
        {
            Aquarium aqua = new Aquarium("devil", 1);
            aqua.Add(new Fish("joni"));


            Assert.Throws<InvalidOperationException>(() => aqua.Add(new Fish("jonqqi")));
        }


        [Test]
        public void AddFish()
        {
            Aquarium aqua = new Aquarium("devil", 1);
            aqua.Add(new Fish("joni"));


            Assert.AreEqual(aqua.Count, 1);
        }

        [Test]
        public void exceptionWhenRemove()
        {
            Aquarium aqua = new Aquarium("devil", 1);

           Exception ex = Assert.Throws<InvalidOperationException>(() => aqua.RemoveFish("jonkata"));

            Assert.AreEqual(ex.Message, "Fish with the name jonkata doesn't exist!");
        }

        [Test]
        public void RemovedFish()
        {
            Aquarium aqua = new Aquarium("devil", 1);
            aqua.Add(new Fish("joni"));


            aqua.RemoveFish("joni");

            Assert.AreEqual(aqua.Count, 0);
        }

        [Test]
        public void NoFishToSell()
        {
            Aquarium aqua = new Aquarium("basi", 4);

            Exception ex = Assert.Throws<InvalidOperationException>(() => aqua.SellFish("jak"));

            Assert.AreEqual(ex.Message, "Fish with the name jak doesn't exist!");
        }

        [Test]
        public void FishToSell()
        {
            Aquarium aqua = new Aquarium("basi", 4);
            Fish fish = new Fish("Joi");
            aqua.Add(fish);

            aqua.SellFish("Joi");

            Assert.IsFalse(fish.Available);
        }

    }

}
