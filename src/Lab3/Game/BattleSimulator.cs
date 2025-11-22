using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Results;
using System.Security.Cryptography;

namespace Itmo.ObjectOrientedProgramming.Lab3.Game;

public class BattleSimulator
{
    private readonly PlayerBoard _firstInitialBoard;

    private readonly PlayerBoard _secondInitialBoard;

    public BattleSimulator(PlayerBoard board1, PlayerBoard board2)
    {
        _firstInitialBoard = board1.Clone();
        _secondInitialBoard = board2.Clone();
    }

    public BattleResult StartBattle()
    {
        PlayerBoard firstBoard = _firstInitialBoard.Clone();
        PlayerBoard secondBoard = _secondInitialBoard.Clone();
        var firstAttackerSelector = new PlayerBoardAttackerSelector(firstBoard);
        var secondAttackerSelector = new PlayerBoardAttackerSelector(secondBoard);

        PlayerBoard attackingBoard = firstBoard;
        PlayerBoard targetsBoard = secondBoard;
        PlayerBoardAttackerSelector attackerSelector = firstAttackerSelector;

        while (true)
        {
            TurnPerformingResult turnResult = PerformTurn(attackerSelector, targetsBoard);

            switch (turnResult)
            {
                case TurnPerformingResult.AttackerPasses:
                case TurnPerformingResult.PerformedNormally:
                    (attackingBoard, targetsBoard) = (targetsBoard, attackingBoard);
                    attackerSelector = (attackerSelector == firstAttackerSelector)
                        ? secondAttackerSelector
                        : firstAttackerSelector;
                    break;

                case TurnPerformingResult.AttackerWins:
                    return attackingBoard == firstBoard
                        ? new BattleResult.FirstWins()
                        : new BattleResult.SecondWins();

                case TurnPerformingResult.GameTied:
                    return new BattleResult.Tied();

                default:
                    throw new InvalidOperationException();
            }
        }
    }

    private TurnPerformingResult PerformTurn(
        PlayerBoardAttackerSelector attackerSelector,
        PlayerBoard targetsBoard)
    {
        ICreature? attacker = attackerSelector.FindNextAttacker();
        var targets = targetsBoard.GetTargets().ToList();

        if (targets.Count == 0 && attacker == null)
            return new TurnPerformingResult.GameTied();

        if (targets.Count == 0)
            return new TurnPerformingResult.AttackerWins();

        if (attacker == null)
            return new TurnPerformingResult.AttackerPasses();

        attacker.Attack(targets[RandomNumberGenerator.GetInt32(targets.Count)]);
        return new TurnPerformingResult.PerformedNormally();
    }
}
