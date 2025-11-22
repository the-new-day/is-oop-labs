using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.Spells;

public class ProtectionAmuletTests
{
    [Fact]
    public void GetCasted_ShouldAddMagicShieldModifier()
    {
        // Arrange
        var amulet = new ProtectionAmulet();
        var creature = new CreatureMock(new AttackPoints(2), new HealthPoints(10));

        // Act
        ICreature result = amulet.GetCasted(creature);

        // Assert
        Assert.IsType<MagicShieldModifier>(result);
    }
}
