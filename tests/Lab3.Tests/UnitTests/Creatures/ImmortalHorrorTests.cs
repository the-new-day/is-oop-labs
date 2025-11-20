using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.Creatures;

public class ImmortalHorrorTests
{
    [Fact]
    public void TakeDamage_NonLethalDamage_ShouldNotActivateReborn()
    {
        // Arrange
        var initialAttackValue = new HealthPoints(4);
        var initialHealthValue = new HealthPoints(4);
        var healthValueAfterRebirth = new HealthPoints(1);

        var horror = new ImmortalHorror(initialAttackValue, initialHealthValue, healthValueAfterRebirth);
        var damage = new HealthPoints(1);

        HealthPoints expectedNewHealthValue = initialHealthValue - damage;

        // Act
        horror.TakeDamage(damage);

        // Assert
        Assert.Equal(horror.HealthValue, expectedNewHealthValue);
    }

    [Fact]
    public void TakeDamage_FirstLethalDamage_ShouldRebornWithGivenHealth()
    {
        // Arrange
        var initialAttackValue = new HealthPoints(4);
        var initialHealthValue = new HealthPoints(4);
        var healthValueAfterRebirth = new HealthPoints(1);

        var horror = new ImmortalHorror(initialAttackValue, initialHealthValue, healthValueAfterRebirth);
        var damage = new HealthPoints(5);

        HealthPoints expectedNewHealthValue = healthValueAfterRebirth;

        // Act
        horror.TakeDamage(damage);

        // Assert
        Assert.Equal(horror.HealthValue, expectedNewHealthValue);
    }

    [Fact]
    public void TakeDamage_SecondLethalDamage_ShouldDiePermanently()
    {
        // Arrange
        var initialAttackValue = new HealthPoints(4);
        var initialHealthValue = new HealthPoints(4);
        var healthValueAfterRebirth = new HealthPoints(1);

        var horror = new ImmortalHorror(initialAttackValue, initialHealthValue, healthValueAfterRebirth);
        var damage = new HealthPoints(5);

        // Act
        horror.TakeDamage(damage);
        horror.TakeDamage(damage);

        // Assert
        Assert.False(horror.IsAlive);
    }

    [Fact]
    public void TakeDamage_ExactLethalDamage_ShouldReborn()
    {
        // Arrange
        var initialAttackValue = new HealthPoints(4);
        var initialHealthValue = new HealthPoints(4);
        var healthValueAfterRebirth = new HealthPoints(1);

        var horror = new ImmortalHorror(initialAttackValue, initialHealthValue, healthValueAfterRebirth);
        var damage = new HealthPoints(4);

        HealthPoints expectedNewHealthValue = healthValueAfterRebirth;

        // Act
        horror.TakeDamage(damage);

        // Assert
        Assert.Equal(horror.HealthValue, expectedNewHealthValue);
    }
}
