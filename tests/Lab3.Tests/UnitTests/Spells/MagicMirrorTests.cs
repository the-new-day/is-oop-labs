using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.Spells;

public class MagicMirrorTests
{
    [Fact]
    public void GetCasted_ShouldAddMagicShieldModifier()
    {
        // Arrange
        var mirror = new MagicMirror();
        var creature = new CreatureMock(new AttackPoints(3), new HealthPoints(8));
        var expectedAttack = new AttackPoints(8);
        var expectedHealth = new HealthPoints(3);

        // Act
        ICreature result = mirror.GetCasted(creature);

        // Assert
        Assert.Equal(expectedAttack, result.AttackValue);
        Assert.Equal(expectedHealth, result.HealthValue);
    }

    [Fact]
    public void ApplyTo_WithEqualStats_ShouldKeepSameValues()
    {
        // Arrange
        var mirror = new MagicMirror();
        var creature = new CreatureMock(new AttackPoints(5), new HealthPoints(5));

        // Act
        ICreature result = mirror.GetCasted(creature);

        // Assert
        Assert.Equal(creature.AttackValue, result.AttackValue);
        Assert.Equal(creature.HealthValue, result.HealthValue);
    }
}
