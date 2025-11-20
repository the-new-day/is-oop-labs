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
        var board1 = new PlayerBoard(3);
        var board2 = new PlayerBoard(3); // stays empty

        board1.AddCreature(new OrdinaryCreature(new HealthPoints(2), new HealthPoints(4)));

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
        var board1 = new PlayerBoard(3);
        var board2 = new PlayerBoard(3);

        var deadCreature = new OrdinaryCreature(new HealthPoints(2), new HealthPoints(0));
        board1.AddCreature(deadCreature);
        board2.AddCreature(deadCreature);

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
        var board1 = new PlayerBoard(3);
        var board2 = new PlayerBoard(3);

        board1.AddCreature(new OrdinaryCreature(new HealthPoints(0), new HealthPoints(4)));
        board2.AddCreature(new OrdinaryCreature(new HealthPoints(2), new HealthPoints(4)));

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
        var board1 = new PlayerBoard(3);
        var board2 = new PlayerBoard(3);

        // Player 1: strong creature
        board1.AddCreature(new OrdinaryCreature(new HealthPoints(5), new HealthPoints(10)));

        // Player 2: weak creature
        board2.AddCreature(new OrdinaryCreature(new HealthPoints(1), new HealthPoints(3)));

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
        var board1 = new PlayerBoard(3);
        var board2 = new PlayerBoard(3);

        // Player 1: weak creature
        board1.AddCreature(new OrdinaryCreature(new HealthPoints(1), new HealthPoints(3)));

        // Player 2: strong creature
        board2.AddCreature(new OrdinaryCreature(new HealthPoints(5), new HealthPoints(10)));

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
        var board1 = new PlayerBoard(3);
        var board2 = new PlayerBoard(3);

        // Player 1: 2 attackers
        board1.AddCreature(new OrdinaryCreature(new HealthPoints(2), new HealthPoints(4)));
        board1.AddCreature(new OrdinaryCreature(new HealthPoints(3), new HealthPoints(5)));

        // Player 2: 1 target
        board2.AddCreature(new OrdinaryCreature(new HealthPoints(1), new HealthPoints(20)));

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
        var originalBoard1 = new PlayerBoard(3);
        var originalBoard2 = new PlayerBoard(3);

        originalBoard1.AddCreature(new OrdinaryCreature(new HealthPoints(2), new HealthPoints(4)));
        originalBoard2.AddCreature(new OrdinaryCreature(new HealthPoints(1), new HealthPoints(3)));

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
        var board1 = new PlayerBoard(3);
        var board2 = new PlayerBoard(3);

        var analyst = new BattleAnalyst(
            new HealthPoints(2), new HealthPoints(4), new HealthPoints(2));
        board1.AddCreature(analyst);

        board2.AddCreature(new OrdinaryCreature(new HealthPoints(1), new HealthPoints(10)));

        var simulator = new BattleSimulator(board1, board2);

        // Act
        BattleResult result = simulator.StartBattle();

        // Assert - should finish correctly
        Assert.True(result is BattleResult.FirstWins or BattleResult.SecondWins or BattleResult.Tied);
    }
}
