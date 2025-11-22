using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.Spells;

public class EndurancePotionTests
{
    [Fact]
    public void GetCasted_ShouldIncreaseHealthValueByBonus()
    {
        // Arrange
        var potion = new EndurancePotion(new HealthPoints(5));
        var creature = new CreatureMock(new AttackPoints(2), new HealthPoints(10));
        var expectedHealth = new HealthPoints(15);

        // Act
        ICreature result = potion.GetCasted(creature);

        // Assert
        Assert.Equal(expectedHealth, result.HealthValue);
        Assert.Equal(creature.AttackValue, result.AttackValue);
    }
}
