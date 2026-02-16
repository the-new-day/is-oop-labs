using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.Creatures;

public class BattleAnalystTests
{
    [Fact]
    public void Attack_FirstTime_ShouldIncreaseAttackValueByBonus()
    {
        // Arrange
        var initialAttackValue = new AttackPoints(2);
        var initialHealthValue = new HealthPoints(4);
        var attackBonus = new AttackPoints(2);

        var analyst = new BattleAnalyst(initialAttackValue, initialHealthValue, attackBonus);
        var target = new CreatureMock(new AttackPoints(1), new HealthPoints(10));

        AttackPoints expectedNewAttackValue = initialAttackValue + attackBonus;

        // Act
        analyst.Attack(target);

        // Assert
        Assert.Equal(expectedNewAttackValue, analyst.AttackValue);
    }

    [Fact]
    public void Attack_MultipleTimes_ShouldIncreaseAttackValueByBonusEachTime()
    {
        // Arrange
        var initialAttackValue = new AttackPoints(2);
        var initialHealthValue = new HealthPoints(4);
        var attackBonus = new AttackPoints(2);

        var analyst = new BattleAnalyst(initialAttackValue, initialHealthValue, attackBonus);
        var target = new CreatureMock(new AttackPoints(1), new HealthPoints(10));

        int timesCount = 3;
        AttackPoints expectedNewAttackValue = initialAttackValue + attackBonus.MultipliedBy(timesCount);

        // Act
        for (int i = 0; i < timesCount; ++i)
        {
            analyst.Attack(target);
        }

        // Assert
        Assert.Equal(expectedNewAttackValue, analyst.AttackValue);
    }
}
