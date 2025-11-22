using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.FunctionalTests;

public class ModifierCombinationTests
{
    [Fact]
    public void MagicShield_WithAttackMastery_ShouldWorkTogether()
    {
        // Arrange
        var baseCreature = new OrdinaryCreature(new AttackPoints(3), new HealthPoints(10));
        var withShield = new MagicShieldModifier(baseCreature);
        var withMastery = new AttackMasteryModifier(withShield);
        var target = new OrdinaryCreature(new AttackPoints(1), new HealthPoints(20));

        // Act & Assert - check if shield works
        withMastery.TakeDamage(new AttackPoints(100));
        Assert.Equal(new HealthPoints(10), withMastery.HealthValue);
        withMastery.TakeDamage(new AttackPoints(5));
        Assert.Equal(new HealthPoints(5), withMastery.HealthValue);

        // Act & Assert - check if double attack works
        HealthPoints healthBefore = target.HealthValue;
        withMastery.Attack(target);
        HealthPoints expectedHealthAfterDoubleAttack = healthBefore - new HealthPoints(6);
        Assert.Equal(expectedHealthAfterDoubleAttack, target.HealthValue);
    }

    [Fact]
    public void AttackMastery_WithMagicShield_ShouldWorkTogether()
    {
        // Arrange
        var baseCreature = new OrdinaryCreature(new AttackPoints(3), new HealthPoints(10));
        var withMastery = new AttackMasteryModifier(baseCreature);
        var withShield = new MagicShieldModifier(withMastery);
        var target = new OrdinaryCreature(new AttackPoints(1), new HealthPoints(20));

        // Act & Assert - check if shield works
        withShield.TakeDamage(new AttackPoints(100));
        Assert.Equal(new HealthPoints(10), withShield.HealthValue);
        withShield.TakeDamage(new AttackPoints(5));
        Assert.Equal(new HealthPoints(5), withShield.HealthValue);

        // Act & Assert - check if double attack works
        HealthPoints healthBefore = target.HealthValue;
        withShield.Attack(target);
        HealthPoints expectedHealthAfterDoubleAttack = healthBefore - new HealthPoints(6);
        Assert.Equal(expectedHealthAfterDoubleAttack, target.HealthValue);
    }

    [Fact]
    public void MultipleMagicShields_ShouldStack()
    {
        // Arrange
        var baseCreature = new OrdinaryCreature(new AttackPoints(2), new HealthPoints(10));
        var withShield1 = new MagicShieldModifier(baseCreature);
        var withShield2 = new MagicShieldModifier(withShield1);

        // Act & Assert - first shield works
        withShield2.TakeDamage(new AttackPoints(100));
        Assert.Equal(10, withShield2.HealthValue.Value);

        // Act & Assert - second shield works
        withShield2.TakeDamage(new AttackPoints(100));
        Assert.Equal(10, withShield2.HealthValue.Value);

        // Act & Assert - third damage hits
        withShield2.TakeDamage(new AttackPoints(5));
        Assert.Equal(5, withShield2.HealthValue.Value);
    }

    [Fact]
    public void MultipleAttackMasteries_ShouldStack()
    {
        // Arrange
        var baseCreature = new OrdinaryCreature(new AttackPoints(2), new HealthPoints(10));
        var withMastery1 = new AttackMasteryModifier(baseCreature);
        var withMastery2 = new AttackMasteryModifier(withMastery1);
        var target = new OrdinaryCreature(new AttackPoints(1), new HealthPoints(50));

        // Act
        withMastery2.Attack(target);

        // Assert
        var expectedDamage = new HealthPoints(2 * 4); // 4 attacks totally
        HealthPoints expectedHealth = new HealthPoints(50) - expectedDamage;
        Assert.Equal(expectedHealth, target.HealthValue);
    }

    [Fact]
    public void ComplexModifierChain_ShouldWorkCorrectly()
    {
        // Arrange
        var baseCreature = new OrdinaryCreature(new AttackPoints(3), new HealthPoints(15));
        var withShield = new MagicShieldModifier(baseCreature);
        var withMastery = new AttackMasteryModifier(withShield);
        var withSecondShield = new MagicShieldModifier(withMastery);
        var target = new OrdinaryCreature(new AttackPoints(1), new HealthPoints(50));

        // Act & Assert - check shields
        withSecondShield.TakeDamage(new AttackPoints(100));
        Assert.Equal(new HealthPoints(15), withSecondShield.HealthValue);

        withSecondShield.TakeDamage(new AttackPoints(100));
        Assert.Equal(new HealthPoints(15), withSecondShield.HealthValue);

        withSecondShield.TakeDamage(new AttackPoints(5));
        Assert.Equal(new HealthPoints(10), withSecondShield.HealthValue);

        // Act & Assert - check attack
        HealthPoints healthBefore = target.HealthValue;
        withSecondShield.Attack(target);
        var expectedDamage = new HealthPoints(2 * 3); // 2 attacks totally

        HealthPoints expectedHealth = new HealthPoints(50) - expectedDamage;
        Assert.Equal(expectedHealth, target.HealthValue);
    }
}
