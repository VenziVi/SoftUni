using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database datebase;

        [SetUp]
        public void Setup()
        {
            datebase = new Database();
        }

        [Test]
        public void AddMethodShouldThrowException()
        {
            int[] arry = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            datebase = new Database(arry);
            Assert.Throws<InvalidOperationException>(() => datebase.Add(17));
        }

        [Test]
        public void AddMethodShouldAddElementsToColection()
        {
            datebase.Add(1);
            datebase.Add(2);

            var expectedResult = 2;
            var actualResult = datebase.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ShouldThrowExceptionWhenRemoveFromEmptyCollection()
        {
            Assert.Throws<InvalidOperationException>(() => datebase.Remove());
        }

        [Test]
        public void RemoveMethodShouldIncreaseCollectionCount()
        {
            datebase.Add(1);
            datebase.Add(2);

            datebase.Remove();

            int expectedResult = 1;
            int actualResult = datebase.Count;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void FetchSouldCreateCopyOfCollection()
        {
            int[] arry = { 1, 2, 3, 4};
            datebase = new Database(arry);

            int[] copy = datebase.Fetch();

            datebase.Add(32);

            int[] secondCopy = datebase.Fetch();

            CollectionAssert.AreNotEqual(copy, secondCopy);
        }

        [Test]
        public void ConstructorShouldSetValuesCorectly()
        {
            int n = 16;

            for (int i = 0; i < n; i++)
            {
                datebase.Add(i);
            }

            Assert.AreEqual(datebase.Count, n);
        }
    }
}