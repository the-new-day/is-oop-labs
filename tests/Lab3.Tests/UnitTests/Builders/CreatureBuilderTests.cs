using Itmo.ObjectOrientedProgramming.Lab3.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.Builders;

public class CreatureBuilderTests
{
    [Fact]
    public void Build_WithBaseStatsOnly_ShouldReturnCreatureWithGivenStats()
    {
        // Arrange
        ICreatureBuilder builder = new CreatureBuilder(new CreatureFactoryMock())
            .WithAttack(new AttackPoints(3))
            .WithHealth(new HealthPoints(8));

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
        ICreatureBuilder builder = new CreatureBuilder(new CreatureFactoryMock())
            .WithAttack(new AttackPoints(3))
            .WithHealth(new HealthPoints(8))
            .WithModifier(new MagicShieldModifierFactory());

        // Act
        ICreature creature = builder.Build();

        // Assert
        Assert.IsType<MagicShieldModifier>(creature, exactMatch: false);
    }

    [Fact]
    public void Build_WithAttackMastery_ShouldReturnCreatureWithAttackMastery()
    {
        // Arrange
        ICreatureBuilder builder = new CreatureBuilder(new CreatureFactoryMock())
            .WithAttack(new AttackPoints(3))
            .WithHealth(new HealthPoints(8))
            .WithModifier(new AttackMasteryModifierFactory());

        // Act
        ICreature creature = builder.Build();

        // Assert
        Assert.IsType<AttackMasteryModifier>(creature, exactMatch: false);
    }

    [Fact]
    public void Build_ShouldReturnNewInstanceEachTime()
    {
        // Arrange
        ICreatureBuilder builder = new CreatureBuilder(new CreatureFactoryMock())
            .WithAttack(new AttackPoints(3))
            .WithHealth(new HealthPoints(8))
            .WithModifier(new MagicShieldModifierFactory());

        // Act
        ICreature creature1 = builder.Build();
        ICreature creature2 = builder.Build();

        // Assert
        Assert.NotSame(creature1, creature2);

        creature1.TakeDamage(new AttackPoints(100));
        Assert.Equal(new HealthPoints(8), creature2.HealthValue);
    }
}
