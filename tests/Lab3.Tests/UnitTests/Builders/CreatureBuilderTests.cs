using Itmo.ObjectOrientedProgramming.Lab3.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.Builders;

public class CreatureBuilderTests
{
    [Fact]
    public void Build_WithBaseStatsOnly_ShouldReturnCreatureWithGivenStats()
    {
        // Arrange
        var builder = new CreatureBuilder(new AttackPoints(3), new HealthPoints(8));

        // Act
        ICreature creature = builder.Build();

        // Assert
        Assert.Equal(new AttackPoints(3), creature.AttackValue);
        Assert.Equal(new HealthPoints(8), creature.HealthValue);
    }

    [Fact]
    public void Build_WithMagicShield_ShouldReturnCreatureWithMagicShield()
    {
        // Arrange
        var builder = new CreatureBuilder(new AttackPoints(3), new HealthPoints(8));
        builder.WithModifier(creature => new MagicShieldModifier(creature));

        // Act
        ICreature creature = builder.Build();

        // Assert
        Assert.IsType<MagicShieldModifier>(creature, exactMatch: false);
    }

    [Fact]
    public void Build_WithAttackMastery_ShouldReturnCreatureWithAttackMastery()
    {
        // Arrange
        var builder = new CreatureBuilder(new AttackPoints(3), new HealthPoints(8));
        builder.WithModifier(creature => new AttackMasteryModifier(creature));

        // Act
        ICreature creature = builder.Build();

        // Assert
        Assert.IsType<AttackMasteryModifier>(creature, exactMatch: false);
    }

    [Fact]
    public void Build_ShouldReturnNewInstanceEachTime()
    {
        // Arrange
        var builder = new CreatureBuilder(new AttackPoints(3), new HealthPoints(8));
        builder.WithModifier(creature => new MagicShieldModifier(creature));

        // Act
        ICreature creature1 = builder.Build();
        ICreature creature2 = builder.Build();

        // Assert
        Assert.NotSame(creature1, creature2);

        creature1.TakeDamage(new AttackPoints(100));
        Assert.Equal(new HealthPoints(8), creature2.HealthValue);
    }
}
