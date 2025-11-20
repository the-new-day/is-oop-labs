using Itmo.ObjectOrientedProgramming.Lab3.CreatureFactories;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.Factories;

public class BattleAnalystFactoryTests
{
    [Fact]
    public void CreateCreature_ShouldReturnBattleAnalystWithCorrectStats()
    {
        // Arrange
        var factory = new BattleAnalystFactory();

        // Act
        ICreature creature = factory.CreateCreature();

        // Assert
        Assert.IsType<BattleAnalyst>(creature);
        Assert.Equal(new HealthPoints(2), creature.AttackValue);
        Assert.Equal(new HealthPoints(4), creature.HealthValue);
    }
}
