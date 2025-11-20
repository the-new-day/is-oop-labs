using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using Itmo.ObjectOrientedProgramming.Lab3.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.Modifiers;

public class MagicShieldModifierTests
{
    [Fact]
    public void TakeDamage_NonLethalDamageOnce_ShouldKeepHealth()
    {
        // Arrange
        var initialAttackValue = new HealthPoints(4);
        var initialHealthValue = new HealthPoints(4);
        var attackerAttackValue = new HealthPoints(1);

        var shieldBaseCreature = new CreatureMock(initialAttackValue, initialHealthValue);
        var attacker = new CreatureMock(attackerAttackValue, initialHealthValue);

        var shield = new MagicShieldModifier(shieldBaseCreature);

        // Act
        attacker.Attack(shield);

        // Assert
        Assert.Equal(initialHealthValue, shield.HealthValue);
    }

    [Fact]
    public void TakeDamage_LethalDamageOnce_ShouldKeepHealth()
    {
        // Arrange
        var initialAttackValue = new HealthPoints(4);
        var initialHealthValue = new HealthPoints(4);
        var attackerAttackValue = new HealthPoints(5);

        var shieldBaseCreature = new CreatureMock(initialAttackValue, initialHealthValue);
        var attacker = new CreatureMock(attackerAttackValue, initialHealthValue);

        var shield = new MagicShieldModifier(shieldBaseCreature);

        // Act
        attacker.Attack(shield);

        // Assert
        Assert.Equal(initialHealthValue, shield.HealthValue);
    }

    [Fact]
    public void TakeDamage_TakesDamageTwice_ShouldBlockFirstAndTakeSecond()
    {
        // Arrange
        var initialAttackValue = new HealthPoints(4);
        var initialHealthValue = new HealthPoints(4);
        var attackerAttackValue = new HealthPoints(1);

        var shieldBaseCreature = new CreatureMock(initialAttackValue, initialHealthValue);
        var attacker = new CreatureMock(attackerAttackValue, initialHealthValue);

        var shield = new MagicShieldModifier(shieldBaseCreature);

        HealthPoints expectedNewHealthValue = initialHealthValue - attackerAttackValue;

        // Act
        attacker.Attack(shield);
        attacker.Attack(shield);

        // Assert
        Assert.Equal(expectedNewHealthValue, shield.HealthValue);
    }
}
