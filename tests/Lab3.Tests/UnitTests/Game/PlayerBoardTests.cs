using Itmo.ObjectOrientedProgramming.Lab3.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Game;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.Game;

public class PlayerBoardTests
{
    [Fact]
    public void GetAttackers_ShouldReturnOnlyCreaturesThatCanAttack()
    {
        // Arrange
        var attacker = new CreatureMock(new AttackPoints(2), new HealthPoints(4));
        var deadCreature = new CreatureMock(new AttackPoints(2), new HealthPoints(0));
        var zeroAttackCreature = new CreatureMock(new AttackPoints(0), new HealthPoints(4));

        var boardBuilder = new PlayerBoardBuilder(3);
        boardBuilder.WithCreature(attacker);
        boardBuilder.WithCreature(deadCreature);
        boardBuilder.WithCreature(zeroAttackCreature);

        PlayerBoard board = boardBuilder.Build();

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
        var aliveCreature = new CreatureMock(new AttackPoints(2), new HealthPoints(4));
        var deadCreature = new CreatureMock(new AttackPoints(2), new HealthPoints(0));

        var boardBuilder = new PlayerBoardBuilder(3);
        boardBuilder.WithCreature(deadCreature);
        boardBuilder.WithCreature(aliveCreature);

        PlayerBoard board = boardBuilder.Build();

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
        var creature = new CreatureMock(new AttackPoints(2), new HealthPoints(4));
        var spell = new SpellMock();

        var boardBuilder = new PlayerBoardBuilder(3);
        boardBuilder.WithCreature(creature);
        PlayerBoard board = boardBuilder.Build();

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
        var spell = new SpellMock();
        var creature = new CreatureMock(new AttackPoints(2), new HealthPoints(4));

        var boardBuilder = new PlayerBoardBuilder(3);
        boardBuilder.WithCreature(creature);
        PlayerBoard board = boardBuilder.Build();

        // Act
        Exception exception = Record.Exception(() => board.CastSpell(spell, creatureIndex: 5));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void CastSpell_WithNegativeIndex_ShouldThrow()
    {
        // Arrange
        var spell = new SpellMock();
        var creature = new CreatureMock(new AttackPoints(2), new HealthPoints(4));

        var boardBuilder = new PlayerBoardBuilder(3);
        boardBuilder.WithCreature(creature);
        PlayerBoard board = boardBuilder.Build();

        // Act
        Exception exception = Record.Exception(() => board.CastSpell(spell, creatureIndex: -1));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void Clone_ShouldCreateDeepCopy()
    {
        // Arrange
        var creature = new CreatureMock(new AttackPoints(2), new HealthPoints(4));
        var spell = new SpellMock();

        var boardBuilder = new PlayerBoardBuilder(3);
        boardBuilder.WithCreature(creature);
        PlayerBoard original = boardBuilder.Build();

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
        var original = new PlayerBoard([]);

        // Act
        PlayerBoard clone = original.Clone();

        // Assert
        Assert.Empty(clone.GetAttackers());
        Assert.Empty(clone.GetTargets());
    }
}
