namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {

        [Test]
        public void NewPresent()
        {
            Present pres = new Present("wow", 10);

            Assert.AreEqual(pres.Name, "wow");
            Assert.AreEqual(pres.Magic, 10);

        }


        [Test]
        public void CreateWithNull()
        {
            Present present = null;
            Bag bag = new Bag();

            Assert.Throws<ArgumentNullException>(() => bag.Create(present));
        }

        [Test]
        public void CreateWithNullMessage()
        {
            Present present = null;
            Bag bag = new Bag();

            Exception ex = Assert.Throws<ArgumentNullException>(() => bag.Create(present));

            Assert.AreEqual(ex.Message, "Value cannot be null. (Parameter 'Present is null')");
        }

        [Test]
        public void CreateExsistingPresent()
        {
            Bag bag = new Bag();
            Present present = new Present("wow", 10);

            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }

        [Test]
        public void CreateExsistingPresentMessage()
        {
            Bag bag = new Bag();
            Present present = new Present("wow", 10);

            bag.Create(present);
            Exception ex = Assert.Throws<InvalidOperationException>(() => bag.Create(present));

            Assert.AreEqual(ex.Message, "This present already exists!");
        }

        [Test]
        public void PresentCount()
        {
            Bag bag = new Bag();
            int count = bag.GetPresents().Count;

            Assert.AreEqual(0, count);
        }

        [Test]
        public void AddPresent()
        {
            Bag bag = new Bag();
            Present present = new Present("wow", 10);
            string massage = bag.Create(present);

            Assert.AreEqual(massage, "Successfully added present wow.");
            
        }

        [Test]
        public void RemovePresent()
        {
            Bag bag = new Bag();
            Present present = new Present("wow", 10);
            bag.Create(present);

            bool message = bag.Remove(present);

            Assert.AreEqual(message, true);
        }

        [Test]
        public void FalseRemovePresent()
        {
            Bag bag = new Bag();
            Present present = new Present("wow", 10);
            Present present1 = new Present("wtttow", 10);
            bag.Create(present);
            

            bool message = bag.Remove(present1);

            Assert.AreEqual(message, false);
        }

        [Test]
        public  void GetPresentWithLeastMagic()
        {
            Bag bag = new Bag();
            Present present = new Present("wow", 10);
            Present present1 = new Present("wow", 12);
            Present present2 = new Present("wow", 16);

            bag.Create(present);
            bag.Create(present1);
            bag.Create(present2);

            Present presentToFind = bag.GetPresentWithLeastMagic();

            Assert.AreEqual(presentToFind, present);
        }

        [Test]
        public void GetPresentWithLeastMagicNull()
        {
            Bag bag = new Bag();            

            //Present presentToFind = bag.GetPresentWithLeastMagic();
            Assert.Throws<InvalidOperationException>(() => bag.GetPresentWithLeastMagic());
            //Assert.AreEqual(presentToFind, null);
        }

        [Test]
        public void GetPresentWithLeastMagicNullMessage()
        {
            Bag bag = new Bag();

            Exception ex = Assert.Throws<InvalidOperationException>(() => bag.GetPresentWithLeastMagic());
            Assert.AreEqual("Sequence contains no elements", ex.Message);
        }

        [Test]
        public void GetPresentByName()
        {
            Bag bag = new Bag();
            Present present = new Present("wow", 10);
            Present present1 = new Present("wqow", 12);
            Present present2 = new Present("worw", 16);

            bag.Create(present);
            bag.Create(present1);
            bag.Create(present2);

            Present presentToFind = bag.GetPresent("wow");

            Assert.AreEqual(presentToFind, present);
        }

        [Test]
        public void GetPresentByNameNull()
        {
            Bag bag = new Bag();
            Present present = new Present("wow", 10);
            Present present1 = new Present("wqow", 12);
            Present present2 = new Present("worw", 16);

            bag.Create(present);
            bag.Create(present1);
            bag.Create(present2);

            Present presentToFind = bag.GetPresent("whatw");

            Assert.AreEqual(presentToFind, null);
        }


        [Test]
        public void GetPresentByNameNulllll()
        {
            Bag bag = new Bag();

            Present presentToFind = bag.GetPresent("whatw");

            Assert.AreEqual(presentToFind, null);
        }

        [Test]
        public void GetPresentsCount()
        {
            Bag bag = new Bag();
            Present present = new Present("wow", 10);
            Present present1 = new Present("wqow", 12);
            Present present2 = new Present("worw", 16);

            bag.Create(present);
            bag.Create(present1);
            bag.Create(present2);

            int count = bag.GetPresents().Count;

            Assert.AreEqual(count, 3);
        }

        [Test]
        public void GetPresentsCountList()
        {
            Bag bag = new Bag();
            Present present = new Present("wow", 10);
            Present present1 = new Present("wqow", 12);
            Present present2 = new Present("worw", 16);

            bag.Create(present);
            bag.Create(present1);
            bag.Create(present2);

            IReadOnlyCollection<Present> pres = bag.GetPresents();
            List<Present> newPres = new List<Present>();
            newPres.Add(present);
            newPres.Add(present1);
            newPres.Add(present2);


            CollectionAssert.AreEqual(newPres, pres);
        }
    }
}
