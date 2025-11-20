using Itmo.ObjectOrientedProgramming.Lab3.CreatureFactories;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.Factories;

public class MimicChestFactoryTests
{
    [Fact]
    public void CreateCreature_ShouldReturnMimicChestWithCorrectStats()
    {
        // Arrange
        var factory = new MimicChestFactory();

        // Act
        ICreature creature = factory.CreateCreature();

        // Assert
        Assert.IsType<MimicChest>(creature);
        Assert.Equal(new HealthPoints(1), creature.AttackValue);
        Assert.Equal(new HealthPoints(1), creature.HealthValue);
    }
}
