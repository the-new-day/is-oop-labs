using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Game;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Results;
using Itmo.ObjectOrientedProgramming.Lab3.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.Game;

public class PlayerBoardTests
{
    [Fact]
    public void AddCreature_WhenBoardHasSpace_ShouldAddCreature()
    {
        // Arrange
        var board = new PlayerBoard(maxCreaturesCount: 3);
        var creature = new CreatureMock(new AttackPoints(2), new HealthPoints(4));

        // Act
        PlayerBoardAddingCreatureResult result = board.AddCreature(creature);
        var attackers = board.GetAttackers().ToList();

        // Assert
        Assert.IsType<PlayerBoardAddingCreatureResult.Success>(result);
        Assert.Single(attackers);

        ICreature addedCreature = attackers[0];

        Assert.Equal(creature.AttackValue, addedCreature.AttackValue);
        Assert.Equal(creature.HealthValue, addedCreature.HealthValue);
    }

    [Fact]
    public void AddCreature_WhenBoardIsFull_ShouldReturnLimitExceeded()
    {
        // Arrange
        var board = new PlayerBoard(maxCreaturesCount: 1);
        var creature1 = new CreatureMock(new AttackPoints(2), new HealthPoints(4));
        var creature2 = new CreatureMock(new AttackPoints(1), new HealthPoints(3));

        board.AddCreature(creature1);

        // Act
        PlayerBoardAddingCreatureResult result = board.AddCreature(creature2);

        // Assert
        PlayerBoardAddingCreatureResult.CreatureLimitExceeded limitExceeded
            = Assert.IsType<PlayerBoardAddingCreatureResult.CreatureLimitExceeded>(result);
        Assert.Equal(1, limitExceeded.Limit);
    }

    [Fact]
    public void GetAttackers_ShouldReturnOnlyCreaturesThatCanAttack()
    {
        // Arrange
        var board = new PlayerBoard(3);
        var attacker = new CreatureMock(new AttackPoints(2), new HealthPoints(4));
        var deadCreature = new CreatureMock(new AttackPoints(2), new HealthPoints(0));
        var zeroAttackCreature = new CreatureMock(new AttackPoints(0), new HealthPoints(4));

        board.AddCreature(attacker);
        board.AddCreature(deadCreature);
        board.AddCreature(zeroAttackCreature);

        var attackers = board.GetAttackers().ToList();

        // Assert
        Assert.Single(attackers);

        ICreature actualAttacker = attackers[0];
        Assert.Equal(attacker.AttackValue, actualAttacker.AttackValue);
        Assert.Equal(attacker.HealthValue, actualAttacker.HealthValue);
    }

    [Fact]
    public void GetTargets_ShouldReturnOnlyAliveCreatures()
    {
        // Arrange
        var board = new PlayerBoard(3);
        var aliveCreature = new CreatureMock(new AttackPoints(2), new HealthPoints(4));
        var deadCreature = new CreatureMock(new AttackPoints(2), new HealthPoints(0));

        board.AddCreature(aliveCreature);
        board.AddCreature(deadCreature);

        // Act
        var targets = board.GetTargets().ToList();

        // Assert
        Assert.Single(targets);

        ICreature actualTarget = targets[0];
        Assert.Equal(aliveCreature.AttackValue, actualTarget.AttackValue);
        Assert.Equal(aliveCreature.HealthValue, actualTarget.HealthValue);
    }

    [Fact]
    public void CastSpell_WithValidIndex_ShouldApplySpellToCreature()
    {
        // Arrange
        var board = new PlayerBoard(3);
        var creature = new CreatureMock(new AttackPoints(2), new HealthPoints(4));
        var spell = new SpellMock();

        board.AddCreature(creature);

        // Act
        board.CastSpell(spell, creatureIndex: 0);

        // Assert
        Assert.NotNull(spell.LastTarget);
        ICreature spelledCreature = spell.LastTarget;

        Assert.Equal(creature.AttackValue, spelledCreature.AttackValue);
        Assert.Equal(creature.HealthValue, spelledCreature.HealthValue);
    }

    [Fact]
    public void CastSpell_WithInvalidIndex_ShouldThrow()
    {
        // Arrange
        var board = new PlayerBoard(3);
        var spell = new SpellMock();

        // Act
        Exception exception = Record.Exception(() => board.CastSpell(spell, creatureIndex: 5));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void CastSpell_WithNegativeIndex_ShouldThrow()
    {
        // Arrange
        var board = new PlayerBoard(3);
        var spell = new SpellMock();

        // Act
        Exception exception = Record.Exception(() => board.CastSpell(spell, creatureIndex: -1));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void Clone_ShouldCreateDeepCopy()
    {
        // Arrange
        var original = new PlayerBoard(3);
        var creature = new CreatureMock(new AttackPoints(2), new HealthPoints(4));
        original.AddCreature(creature);

        // Act
        PlayerBoard clone = original.Clone();

        ICreature cloneCreature = clone.GetAttackers().First();
        cloneCreature.TakeDamage(new AttackPoints(10));

        // Assert
        Assert.NotSame(original, clone);
        Assert.Empty(clone.GetAttackers());
        Assert.NotEmpty(original.GetAttackers());

        Assert.Equal(new HealthPoints(4), original.GetAttackers().First().HealthValue);
    }

    [Fact]
    public void Clone_EmptyBoard_ShouldCreateEmptyCopy()
    {
        // Arrange
        var original = new PlayerBoard(3);

        // Act
        PlayerBoard clone = original.Clone();

        // Assert
        Assert.Empty(clone.GetAttackers());
        Assert.Empty(clone.GetTargets());
    }
}
