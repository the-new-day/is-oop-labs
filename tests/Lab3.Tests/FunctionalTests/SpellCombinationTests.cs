using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.FunctionalTests;

public class SpellCombinationTests
{
    [Fact]
    public void MultipleSpells_ShouldApplyInSequence()
    {
        // Arrange
        var strengthPotion = new StrengthPotion(new HealthPoints(2));
        var endurancePotion = new EndurancePotion(new HealthPoints(3));
        var creature = new CreatureMock(new HealthPoints(1), new HealthPoints(5));

        // Act
        ICreature stronger = strengthPotion.GetCasted(creature);
        ICreature tougher = endurancePotion.GetCasted(stronger);

        // Assert
        Assert.Equal(new HealthPoints(3), tougher.AttackValue);
        Assert.Equal(new HealthPoints(8), tougher.HealthValue);
    }

    [Fact]
    public void StrengthPotion_AfterMagicMirror_ShouldWorkCorrectly()
    {
        // Arrange
        var mirror = new MagicMirror();
        var potion = new StrengthPotion(new HealthPoints(3));
        var creature = new CreatureMock(new HealthPoints(2), new HealthPoints(6));

        // Act
        ICreature mirrored = mirror.GetCasted(creature);
        ICreature buffed = potion.GetCasted(mirrored);

        // Assert
        Assert.Equal(new HealthPoints(9), buffed.AttackValue);
        Assert.Equal(new HealthPoints(2), buffed.HealthValue);
    }
}
