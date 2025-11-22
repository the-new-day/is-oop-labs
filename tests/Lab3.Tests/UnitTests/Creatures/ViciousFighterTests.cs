using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.Creatures;

public class ViciousFighterTests
{
    [Fact]
    public void TakeDamage_StaysAlive_ShouldMultiplyAttackValueByMultiplier()
    {
        // Arrange
        var initialAttackValue = new AttackPoints(1);
        var initialHealthValue = new HealthPoints(6);
        int multiplier = 2;

        var fighter = new ViciousFighter(initialAttackValue, initialHealthValue, multiplier);
        var damage = new AttackPoints(1);

        AttackPoints expectedNewAttackValue = initialAttackValue.MultipliedBy(multiplier);

        // Act
        fighter.TakeDamage(damage);

        // Assert
        Assert.Equal(fighter.AttackValue, expectedNewAttackValue);
    }

    [Fact]
    public void TakeDamage_StaysAliveMultipleTimes_ShouldMultiplyAttackValueExponentially()
    {
        // Arrange
        var initialAttackValue = new AttackPoints(1);
        var initialHealthValue = new HealthPoints(6);
        int multiplier = 2;

        var fighter = new ViciousFighter(initialAttackValue, initialHealthValue, multiplier);
        var damage = new AttackPoints(1);

        AttackPoints expectedNewAttackValue = initialAttackValue;

        int timesCount = 3;

        for (int i = 0; i < timesCount; ++i)
        {
            expectedNewAttackValue = expectedNewAttackValue.MultipliedBy(multiplier);
        }

        // Act
        for (int i = 0; i < timesCount; ++i)
        {
            fighter.TakeDamage(damage);
        }

        // Assert
        Assert.Equal(expectedNewAttackValue, fighter.AttackValue);
    }

    [Fact]
    public void TakeDamage_WhenDies_ShouldNotIncreaseAttackValue()
    {
        // Arrange
        var initialAttackValue = new AttackPoints(1);
        var initialHealthValue = new HealthPoints(6);
        int multiplier = 2;

        var fighter = new ViciousFighter(initialAttackValue, initialHealthValue, multiplier);
        var damage = new AttackPoints(10);

        // Act
        fighter.TakeDamage(damage);

        // Assert
        Assert.Equal(initialAttackValue, fighter.AttackValue);
    }

    [Fact]
    public void TakeDamage_TakesExactLethalDamage_ShouldNotIncreaseAttackValue()
    {
        // Arrange
        var initialAttackValue = new AttackPoints(1);
        var initialHealthValue = new HealthPoints(6);
        int multiplier = 2;

        var fighter = new ViciousFighter(initialAttackValue, initialHealthValue, multiplier);
        var damage = new AttackPoints(6);

        // Act
        fighter.TakeDamage(damage);

        // Assert
        Assert.Equal(initialAttackValue, fighter.AttackValue);
    }
}
