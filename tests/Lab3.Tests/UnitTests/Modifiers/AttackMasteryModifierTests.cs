using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using Itmo.ObjectOrientedProgramming.Lab3.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.Modifiers;

public class AttackMasteryModifierTests
{
    [Fact]
    public void Attack_NonLethalDamage_ShouldAttackTwice()
    {
        // Arrange
        var initialAttackValue = new AttackPoints(4);
        var initialHealthValue = new HealthPoints(4);
        var initialTargetAttackValue = new AttackPoints(10);
        var initialTargetHealthValue = new HealthPoints(10);

        var masteryBaseCreature = new CreatureMock(initialAttackValue, initialHealthValue);
        var target = new CreatureMock(initialTargetAttackValue, initialTargetHealthValue);

        var mastery = new AttackMasteryModifier(masteryBaseCreature);

        int expectedHitCount = 2;
        HealthPoints expectedNewTargetHealth =
            initialTargetHealthValue.ReducedByDamage(initialAttackValue.MultipliedBy(expectedHitCount));

        // Act
        mastery.Attack(target);

        // Assert
        Assert.Equal(expectedNewTargetHealth, target.HealthValue);
        Assert.Equal(expectedHitCount, target.HitCount);
    }

    [Fact]
    public void Attack_TargetDiesAfterFirstHit_ShouldLeaveTargetDead()
    {
        // Arrange
        var initialAttackValue = new AttackPoints(4);
        var initialHealthValue = new HealthPoints(4);
        var initialTargetAttackValue = new AttackPoints(10);
        var initialTargetHealthValue = new HealthPoints(4);

        var masteryBaseCreature = new CreatureMock(initialAttackValue, initialHealthValue);
        var target = new CreatureMock(initialTargetAttackValue, initialTargetHealthValue);

        var mastery = new AttackMasteryModifier(masteryBaseCreature);

        var expectedNewTargetHealth = new HealthPoints(0);

        // Act
        mastery.Attack(target);

        // Assert
        Assert.Equal(expectedNewTargetHealth, target.HealthValue);
    }
}
