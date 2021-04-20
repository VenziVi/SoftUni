using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void ArenaInicializeWarriors()
        {
            Assert.That(this.arena.Warriors, Is.Not.Null);
        }

        [Test]
        public void EnrollShouldAddWarrior()
        {
            Warrior warrior = new Warrior("Warrior", 50, 50);
            arena.Enroll(warrior);

            var expectedResult = 1;

            Assert.That(arena.Count, Is.EqualTo(expectedResult));
        }

        [Test]
        public void EnrollShouldThrowExceptionIfNameExsist()
        {
            Warrior warrior = new Warrior("Warrior", 50, 50);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(new Warrior("Warrior", 100, 100)));
        }

        [Test]
        public void FightThrowExceptionIfAtaccerIsMissing()
        {
            arena.Enroll(new Warrior("name", 50, 50));

            Assert.Throws<InvalidOperationException>(() => arena.Fight("name", "defender"));
        }

        [Test]
        public void FightThrowExceptionIfDefenderIsMissing()
        {
            arena.Enroll(new Warrior("name", 50, 50));

            Assert.Throws<InvalidOperationException>(() => arena.Fight("attacer", "name"));
        }

        [Test]
        public void FightThrowExceptionIfBothFightersAreMissing()
        {
            Assert.Throws<InvalidOperationException>(() => arena.Fight("attacer", "defender"));
        }

        [Test]
        public void FightBouthFightersLoseHP()
        {
            var initialHp = 100;

            var attaker = new Warrior("attacer", 50, initialHp);
            var defender = new Warrior("defender", 50, initialHp);

            arena.Enroll(attaker);
            arena.Enroll(defender);

            arena.Fight(attaker.Name, defender.Name);

            Assert.That(attaker.HP, Is.EqualTo(initialHp - defender.Damage));
            Assert.That(defender.HP, Is.EqualTo(initialHp - attaker.Damage));
        }
    }
}
