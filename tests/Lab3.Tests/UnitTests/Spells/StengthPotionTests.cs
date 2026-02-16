using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.Spells;

public class StengthPotionTests
{
    [Fact]
    public void GetCasted_ShouldIncreaseAttackValueByBonus()
    {
        // Arrange
        var potion = new StrengthPotion(new AttackPoints(5));
        var creature = new CreatureMock(new AttackPoints(2), new HealthPoints(10));
        var expectedAttack = new AttackPoints(7);

        // Act
        ICreature result = potion.GetCasted(creature);

        // Assert
        Assert.Equal(expectedAttack, result.AttackValue);
        Assert.Equal(creature.HealthValue, result.HealthValue);
    }
}
