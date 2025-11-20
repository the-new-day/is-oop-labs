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
        var builder = new CreatureBuilder(new HealthPoints(3), new HealthPoints(8));

        // Act
        ICreature creature = builder.Build();

        // Assert
        Assert.Equal(new HealthPoints(3), creature.AttackValue);
        Assert.Equal(new HealthPoints(8), creature.HealthValue);
    }

    [Fact]
    public void Build_WithMagicShield_ShouldReturnCreatureWithMagicShield()
    {
        // Arrange
        var builder = new CreatureBuilder(new HealthPoints(3), new HealthPoints(8));
        builder.WithMagicShield();

        // Act
        ICreature creature = builder.Build();

        // Assert
        Assert.IsType<MagicShieldModifier>(creature, exactMatch: false);
    }

    [Fact]
    public void Build_WithAttackMastery_ShouldReturnCreatureWithAttackMastery()
    {
        // Arrange
        var builder = new CreatureBuilder(new HealthPoints(3), new HealthPoints(8));
        builder.WithAttackMastery();

        // Act
        ICreature creature = builder.Build();

        // Assert
        Assert.IsType<AttackMasteryModifier>(creature, exactMatch: false);
    }

    [Fact]
    public void Build_ShouldReturnNewInstanceEachTime()
    {
        // Arrange
        var builder = new CreatureBuilder(new HealthPoints(3), new HealthPoints(8));
        builder.WithMagicShield();

        // Act
        ICreature creature1 = builder.Build();
        ICreature creature2 = builder.Build();

        // Assert
        Assert.NotSame(creature1, creature2);

        creature1.TakeDamage(new HealthPoints(100));
        Assert.Equal(new HealthPoints(8), creature2.HealthValue);
    }
}
