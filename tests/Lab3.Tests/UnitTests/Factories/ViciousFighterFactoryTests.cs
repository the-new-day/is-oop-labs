using Itmo.ObjectOrientedProgramming.Lab3.CreatureFactories;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.Factories;

public class ViciousFighterFactoryTests
{
    [Fact]
    public void CreateCreature_ShouldReturnViciousFighterWithCorrectStats()
    {
        // Arrange
        var factory = new ViciousFighterFactory();

        // Act
        ICreature creature = factory.CreateCreature();

        // Assert
        Assert.IsType<ViciousFighter>(creature);
        Assert.Equal(new AttackPoints(1), creature.AttackValue);
        Assert.Equal(new HealthPoints(6), creature.HealthValue);
    }
}
