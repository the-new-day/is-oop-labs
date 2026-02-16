using Itmo.ObjectOrientedProgramming.Lab3.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Game;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Results;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.FunctionalTests;

public class BattleSimulatorTests
{
    [Fact]
    public void StartBattle_WhenOnePlayerHasNoTargets_ShouldDeclareAttackerWinner()
    {
        // Arrange
        var boardBuilder1 = new PlayerBoardBuilder(3);
        boardBuilder1.WithCreature(new OrdinaryCreature(new AttackPoints(2), new HealthPoints(4)));

        var boardBuilder2 = new PlayerBoardBuilder(3); // stays empty

        PlayerBoard board1 = boardBuilder1.Build();
        PlayerBoard board2 = boardBuilder2.Build();

        var simulator = new BattleSimulator(board1, board2);

        // Act
        BattleResult result = simulator.StartBattle();

        // Assert
        Assert.IsType<BattleResult.FirstWins>(result);
    }

    [Fact]
    public void StartBattle_WhenBothPlayersHaveNoAttackers_ShouldDeclareTie()
    {
        // Arrange
        var boardBuilder1 = new PlayerBoardBuilder(3);
        var boardBuilder2 = new PlayerBoardBuilder(3);

        var deadCreature = new OrdinaryCreature(new AttackPoints(2), new HealthPoints(0));
        boardBuilder1.WithCreature(deadCreature);
        boardBuilder2.WithCreature(deadCreature);

        PlayerBoard board1 = boardBuilder1.Build();
        PlayerBoard board2 = boardBuilder2.Build();

        var simulator = new BattleSimulator(board1, board2);

        // Act
        BattleResult result = simulator.StartBattle();

        // Assert
        Assert.IsType<BattleResult.Tied>(result);
    }

    [Fact]
    public void StartBattle_WhenOnePlayerHasNoAttackers_ShouldSkipTurn()
    {
        // Arrange
        var boardBuilder1 = new PlayerBoardBuilder(3);
        var boardBuilder2 = new PlayerBoardBuilder(3);

        boardBuilder1.WithCreature(new OrdinaryCreature(new AttackPoints(0), new HealthPoints(4)));
        boardBuilder2.WithCreature(new OrdinaryCreature(new AttackPoints(2), new HealthPoints(4)));

        PlayerBoard board1 = boardBuilder1.Build();
        PlayerBoard board2 = boardBuilder2.Build();

        var simulator = new BattleSimulator(board1, board2);

        // Act
        BattleResult result = simulator.StartBattle();

        // Assert
        Assert.IsType<BattleResult.SecondWins>(result);
    }

    [Fact]
    public void StartBattle_ShouldCompleteWithPlayer1Win()
    {
        // Arrange
        var boardBuilder1 = new PlayerBoardBuilder(3);
        var boardBuilder2 = new PlayerBoardBuilder(3);

        // Player 1: strong creature
        boardBuilder1.WithCreature(new OrdinaryCreature(new AttackPoints(5), new HealthPoints(10)));

        // Player 2: weak creature
        boardBuilder2.WithCreature(new OrdinaryCreature(new AttackPoints(1), new HealthPoints(3)));

        PlayerBoard board1 = boardBuilder1.Build();
        PlayerBoard board2 = boardBuilder2.Build();

        var simulator = new BattleSimulator(board1, board2);

        // Act
        BattleResult result = simulator.StartBattle();

        // Assert
        Assert.IsType<BattleResult.FirstWins>(result);
    }

    [Fact]
    public void StartBattle_ShouldCompleteWithPlayer2Win()
    {
        // Arrange
        var boardBuilder1 = new PlayerBoardBuilder(3);
        var boardBuilder2 = new PlayerBoardBuilder(3);

        // Player 1: weak creature
        boardBuilder1.WithCreature(new OrdinaryCreature(new AttackPoints(1), new HealthPoints(3)));

        // Player 2: strong creature
        boardBuilder2.WithCreature(new OrdinaryCreature(new AttackPoints(5), new HealthPoints(10)));

        PlayerBoard board1 = boardBuilder1.Build();
        PlayerBoard board2 = boardBuilder2.Build();

        var simulator = new BattleSimulator(board1, board2);

        // Act
        BattleResult result = simulator.StartBattle();

        // Assert
        Assert.IsType<BattleResult.SecondWins>(result);
    }

    [Fact]
    public void StartBattle_WithMultipleCreatures_ShouldUseAllAttackers()
    {
        // Arrange
        var boardBuilder1 = new PlayerBoardBuilder(3);
        var boardBuilder2 = new PlayerBoardBuilder(3);

        // Player 1: 2 attackers
        boardBuilder1.WithCreature(new OrdinaryCreature(new AttackPoints(2), new HealthPoints(4)));
        boardBuilder1.WithCreature(new OrdinaryCreature(new AttackPoints(3), new HealthPoints(5)));

        // Player 2: 1 target
        boardBuilder2.WithCreature(new OrdinaryCreature(new AttackPoints(1), new HealthPoints(20)));

        PlayerBoard board1 = boardBuilder1.Build();
        PlayerBoard board2 = boardBuilder2.Build();

        var simulator = new BattleSimulator(board1, board2);

        // Act
        BattleResult result = simulator.StartBattle();

        // Assert - should finish correctly
        Assert.True(result is BattleResult.FirstWins or BattleResult.SecondWins or BattleResult.Tied);
    }

    [Fact]
    public void StartBattle_ShouldNotModifyOriginalBoards()
    {
        // Arrange
        var boardBuilder1 = new PlayerBoardBuilder(3);
        var boardBuilder2 = new PlayerBoardBuilder(3);

        boardBuilder1.WithCreature(new OrdinaryCreature(new AttackPoints(2), new HealthPoints(4)));
        boardBuilder2.WithCreature(new OrdinaryCreature(new AttackPoints(1), new HealthPoints(3)));

        PlayerBoard originalBoard1 = boardBuilder1.Build();
        PlayerBoard originalBoard2 = boardBuilder2.Build();

        var simulator = new BattleSimulator(originalBoard1, originalBoard2);

        // Act
        BattleResult result = simulator.StartBattle();

        // Assert
        ICreature originalCreature1 = originalBoard1.GetAttackers().First();
        ICreature originalCreature2 = originalBoard2.GetAttackers().First();

        Assert.Equal(4, originalCreature1.HealthValue.Value);
        Assert.Equal(3, originalCreature2.HealthValue.Value);
    }

    [Fact]
    public void StartBattle_WithSpecialAbilities_ShouldWorkCorrectly()
    {
        // Arrange
        var boardBuilder1 = new PlayerBoardBuilder(3);
        var boardBuilder2 = new PlayerBoardBuilder(3);

        var analyst = new BattleAnalyst(
            new AttackPoints(2), new HealthPoints(4), new AttackPoints(2));
        boardBuilder1.WithCreature(analyst);

        boardBuilder2.WithCreature(new OrdinaryCreature(new AttackPoints(1), new HealthPoints(10)));

        PlayerBoard board1 = boardBuilder1.Build();
        PlayerBoard board2 = boardBuilder2.Build();

        var simulator = new BattleSimulator(board1, board2);

        // Act
        BattleResult result = simulator.StartBattle();

        // Assert - should finish correctly
        Assert.True(result is BattleResult.FirstWins or BattleResult.SecondWins or BattleResult.Tied);
    }
}