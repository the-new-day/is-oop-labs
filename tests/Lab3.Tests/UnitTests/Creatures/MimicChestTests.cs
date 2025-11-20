using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.Creatures;

public class MimicChestTests
{
    [Fact]
    public void Attack_TargetHasHigherStats_ShouldCopyBothStats()
    {
        // Arrange
        var initialAttackValue = new HealthPoints(1);
        var initialHealthValue = new HealthPoints(1);
        var targetAttackValue = new HealthPoints(3);
        var targetHealthValue = new HealthPoints(3);

        var mimicChest = new MimicChest(initialAttackValue, initialHealthValue);
        var targetWithHigherStats = new CreatureMock(targetAttackValue, targetHealthValue);

        HealthPoints expectedNewAttackValue = targetAttackValue;
        HealthPoints expectedNewHealthValue = targetHealthValue;

        // Act
        mimicChest.Attack(targetWithHigherStats);

        // Assert
        Assert.Equal(expectedNewAttackValue, mimicChest.AttackValue);
        Assert.Equal(expectedNewHealthValue, mimicChest.HealthValue);
    }

    [Fact]
    public void Attack_TargetHasLowerStats_ShouldKeepOriginalStats()
    {
        // Arrange
        var initialAttackValue = new HealthPoints(2);
        var initialHealthValue = new HealthPoints(2);
        var targetAttackValue = new HealthPoints(1);
        var targetHealthValue = new HealthPoints(1);

        var mimicChest = new MimicChest(initialAttackValue, initialHealthValue);
        var targetWithLowerStats = new CreatureMock(targetAttackValue, targetHealthValue);

        HealthPoints expectedNewAttackValue = initialAttackValue;
        HealthPoints expectedNewHealthValue = initialHealthValue;

        // Act
        mimicChest.Attack(targetWithLowerStats);

        // Assert
        Assert.Equal(expectedNewAttackValue, mimicChest.AttackValue);
        Assert.Equal(expectedNewHealthValue, mimicChest.HealthValue);
    }

    [Fact]
    public void Attack_TargetHasHigherAttackOnly_ShouldCopyAttackOnly()
    {
        // Arrange
        var initialAttackValue = new HealthPoints(1);
        var initialHealthValue = new HealthPoints(1);
        var targetAttackValue = new HealthPoints(3);
        var targetHealthValue = new HealthPoints(1);

        var mimicChest = new MimicChest(initialAttackValue, initialHealthValue);
        var targetWithHigherStat = new CreatureMock(targetAttackValue, targetHealthValue);

        HealthPoints expectedNewAttackValue = targetAttackValue;
        HealthPoints expectedNewHealthValue = initialHealthValue;

        // Act
        mimicChest.Attack(targetWithHigherStat);

        // Assert
        Assert.Equal(expectedNewAttackValue, mimicChest.AttackValue);
        Assert.Equal(expectedNewHealthValue, mimicChest.HealthValue);
    }

    [Fact]
    public void Attack_TargetHasLowerHealthOnly_ShouldKeepOriginalStats()
    {
        // Arrange
        var initialAttackValue = new HealthPoints(2);
        var initialHealthValue = new HealthPoints(2);
        var targetAttackValue = new HealthPoints(2);
        var targetHealthValue = new HealthPoints(1);

        var mimicChest = new MimicChest(initialAttackValue, initialHealthValue);
        var targetWithHigherStat = new CreatureMock(targetAttackValue, targetHealthValue);

        HealthPoints expectedNewAttackValue = initialAttackValue;
        HealthPoints expectedNewHealthValue = initialHealthValue;

        // Act
        mimicChest.Attack(targetWithHigherStat);

        // Assert
        Assert.Equal(expectedNewAttackValue, mimicChest.AttackValue);
        Assert.Equal(expectedNewHealthValue, mimicChest.HealthValue);
    }

    [Fact]
    public void Attack_MultipleTargets_ShouldKeepHighestStats()
    {
        // Arrange
        var initialAttackValue = new HealthPoints(1);
        var initialHealthValue = new HealthPoints(1);

        var mimicChest = new MimicChest(initialAttackValue, initialHealthValue);
        var target1 = new CreatureMock(new HealthPoints(1), new HealthPoints(3));
        var target2 = new CreatureMock(new HealthPoints(0), new HealthPoints(1));
        var target3 = new CreatureMock(new HealthPoints(10), new HealthPoints(2));

        var expectedNewAttackValue = new HealthPoints(10);
        var expectedNewHealthValue = new HealthPoints(3);

        // Act
        mimicChest.Attack(target1);
        mimicChest.Attack(target2);
        mimicChest.Attack(target3);

        // Assert
        Assert.Equal(expectedNewAttackValue, mimicChest.AttackValue);
        Assert.Equal(expectedNewHealthValue, mimicChest.HealthValue);
    }
}
