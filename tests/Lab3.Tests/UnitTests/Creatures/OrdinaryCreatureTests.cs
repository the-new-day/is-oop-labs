using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.Creatures;

public class OrdinaryCreatureTests
{
    [Fact]
    public void TakeDamage_NonLethalDamage_ShouldDecreaseHealth()
    {
        // Arrange
        var initialAttackValue = new AttackPoints(4);
        var initialHealthValue = new HealthPoints(4);

        var creature = new OrdinaryCreature(initialAttackValue, initialHealthValue);
        var damage = new AttackPoints(1);

        HealthPoints expectedNewHealthValue = initialHealthValue.ReducedByDamage(damage);

        // Act
        creature.TakeDamage(damage);

        // Assert
        Assert.Equal(expectedNewHealthValue, creature.HealthValue);
    }

    [Fact]
    public void TakeDamage_MoreThanLethalDamage_ShouldDecreaseHealthToZero()
    {
        // Arrange
        var initialAttackValue = new AttackPoints(4);
        var initialHealthValue = new HealthPoints(4);

        var creature = new OrdinaryCreature(initialAttackValue, initialHealthValue);
        var damage = new AttackPoints(5);

        var expectedNewHealthValue = new HealthPoints(0);

        // Act
        creature.TakeDamage(damage);

        // Assert
        Assert.Equal(expectedNewHealthValue, creature.HealthValue);
    }

    [Fact]
    public void Attack_NonLethalToOtherCreature_ShouldDecreaseHealthOfOtherCreature()
    {
        // Arrange
        var initialAttackValue = new AttackPoints(2);
        var initialHealthValue = new HealthPoints(4);

        var creature1 = new OrdinaryCreature(initialAttackValue, initialHealthValue);
        var creature2 = new OrdinaryCreature(initialAttackValue, initialHealthValue);

        HealthPoints expectedNewHealthValue2 = initialHealthValue.ReducedByDamage(initialAttackValue);

        // Act
        creature1.Attack(creature2);

        // Assert
        Assert.Equal(expectedNewHealthValue2, creature2.HealthValue);
    }

    [Fact]
    public void Attack_LethalToOtherCreature_ShouldDecreaseHealthOfOtherCreatureToZero()
    {
        // Arrange
        var initialAttackValue = new AttackPoints(5);
        var initialHealthValue = new HealthPoints(4);

        var creature1 = new OrdinaryCreature(initialAttackValue, initialHealthValue);
        var creature2 = new OrdinaryCreature(initialAttackValue, initialHealthValue);

        var expectedNewHealthValue2 = new HealthPoints(0);

        // Act
        creature1.Attack(creature2);

        // Assert
        Assert.Equal(expectedNewHealthValue2, creature2.HealthValue);
    }
}
