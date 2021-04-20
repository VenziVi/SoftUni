using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        //private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            //warrior = new Warrior("Ivan", 55, 40);
        }

        [Test]
        [TestCase("Ivan", 50, 50)]
        public void ConstructorShouldSetValuesCorectly(string name, int damage, int hp)
        {
            Warrior warrior = new Warrior(name, damage, hp);

            Assert.AreEqual(warrior.Name, name);
            Assert.AreEqual(warrior.Damage, damage);
            Assert.AreEqual(warrior.HP, hp);
        }

        [Test]
        [TestCase(" ")]
        [TestCase(null)]
        public void NameThrowsExceptionIfNullOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 50, 50));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-15)]
        public void DamageThrowsExceptionIfNullOrNegative(int damage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Name", damage, 50));
        }

        [Test]
        [TestCase(-15)]
        public void HpThrowsExceptionIfNegative(int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Name", 50, hp));
        }

        [Test]
        [TestCase(15, 55)]
        [TestCase(30, 55)]
        [TestCase(55, 15)]
        [TestCase(55, 30)]
        public void AttacThrowsExceptionIfHpIsLessThanMinValue(int attcerHp, int warriorHp)
        {
            Warrior attacer = new Warrior("Stoqn", 50, attcerHp);
            Warrior warrior = new Warrior("Ivan", 30, warriorHp);

            Assert.Throws<InvalidOperationException>(() => attacer.Attack(warrior));
        }

        [Test]
        [TestCase(55)]
        public void AttacThrowsExceptionIfHpIsLessThanDamage(int damage)
        {
            Warrior attacer = new Warrior("Stoqn", 35, 40);
            Warrior warrior = new Warrior("Ivan", damage, 55);

            Assert.Throws<InvalidOperationException>(() => attacer.Attack(warrior));
        }

        [Test]
        public void AttacDecreaseWarriorHpWithDamageValue()
        {
            Warrior attacer = new Warrior("Stoqn", 50, 100);            
            Warrior warrior = new Warrior("Ivan", 30, 100);

            var expectedHp = attacer.HP - warrior.Damage;

            attacer.Attack(warrior);

            Assert.AreEqual(expectedHp, attacer.HP);
        }

        [Test]
        public void AfterAttacWarriorHpShouldBySetToZeroIfLessThanAttacerDamage()
        {
            Warrior attacer = new Warrior("Stoqn", 100, 100);
            Warrior warrior = new Warrior("Ivan", 100, 90);

            var expectedHp = 0;

            attacer.Attack(warrior);

            Assert.AreEqual(expectedHp, warrior.HP);
        }

        [Test]
        public void AttacDecreaseAttacerHpWithDamageValue()
        {
            Warrior attacer = new Warrior("Stoqn", 50, 100);
            Warrior warrior = new Warrior("Ivan", 30, 100);

            var expectedHp = warrior.HP - attacer.Damage;

            attacer.Attack(warrior);

            Assert.AreEqual(expectedHp, warrior.HP);
        }
    }
}