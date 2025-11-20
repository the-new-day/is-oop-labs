using Itmo.ObjectOrientedProgramming.Lab3.CreatureFactories;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.Factories;

public class ImmortalHorrorFactoryTests
{
    [Fact]
    public void CreateCreature_ShouldReturnImmortalHorrorWithCorrectStats()
    {
        // Arrange
        var factory = new ImmortalHorrorFactory();

        // Act
        ICreature creature = factory.CreateCreature();

        // Assert
        Assert.IsType<ImmortalHorror>(creature);
        Assert.Equal(new HealthPoints(4), creature.AttackValue);
        Assert.Equal(new HealthPoints(4), creature.HealthValue);
    }
}
