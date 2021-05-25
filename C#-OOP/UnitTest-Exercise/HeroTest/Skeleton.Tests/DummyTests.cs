using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    [Test]
    public void Should_LooseHealthWhen_Attaked()
    {
        Dummy dummy = new Dummy(10, 10);

        dummy.TakeAttack(5);

        Assert.That(dummy.Health, Is.EqualTo(5), "dummy health dosen't change after attac");
    }

    [Test]
    public void IfDeadShould_ThrowExeptionWhen_Attaked()
    {
        Dummy dummy = new Dummy(0, 10);

        Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(5));
    }

    [Test]
    public void DeadCanGiveXP()
    {
        Dummy dummy = new Dummy(0, 10);

        var ex = dummy.GiveExperience();

        Assert.That(ex, Is.EqualTo(10));     
    }

    [Test]
    public void AliveCantGiveXP()
    {
        Dummy dummy = new Dummy(100, 10);

        Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
    }
}
