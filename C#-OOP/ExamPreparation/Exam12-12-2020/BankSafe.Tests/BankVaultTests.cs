using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    namespace BankSafe.Tests
    {
        public class BankVaultTests
        {
            private BankVault vault;
            private Item item;

            [SetUp]
            public void Setup()
            {
                vault = new BankVault();
                item = new Item("ko", "1");
            }

            [Test]
            public void ThrowExceptionIfCellDoesNotExists()
            {
                Assert.Throws<ArgumentException>(() => vault.AddItem("n", item));
            }

            [Test]
            public void ThrowExceptionIfCellIsTaken()
            {
                vault.AddItem("A1", item);

                Assert.Throws<ArgumentException>(() => vault.AddItem("A1", item));
            }

            [Test]
            public void ThrowExceptionIfValueExists()
            {
                vault.AddItem("A1", item);

                Assert.Throws<InvalidOperationException>(() => vault.AddItem("A3", item));
            }

            [Test]
            public void ShouldAddValue()
            {
                vault.AddItem("A1", item);
                Item item1 = vault.VaultCells["A1"];

                Assert.AreEqual(item, item1);
            }

            [Test]
            public void ThrowExceptionWhenItemDosentExists()
            {
                Assert.Throws<ArgumentException>(() => vault.RemoveItem("A3", item));
            }
        }
    }
}