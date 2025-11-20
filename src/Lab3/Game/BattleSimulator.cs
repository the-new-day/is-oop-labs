using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Results;
using System.Security.Cryptography;

namespace Itmo.ObjectOrientedProgramming.Lab3.Game;

public class BattleSimulator
{
    private readonly IPlayerBoard _initialBoard1;

    private readonly IPlayerBoard _initialBoard2;

    public BattleSimulator(IPlayerBoard board1, IPlayerBoard board2)
    {
        _initialBoard1 = board1.Clone();
        _initialBoard2 = board2.Clone();
    }

    public BattleResult StartBattle()
    {
        IPlayerBoard board1 = _initialBoard1.Clone();
        IPlayerBoard board2 = _initialBoard2.Clone();
        var attackerSelector1 = new PlayerBoardAttackerSelector(board1);
        var attackerSelector2 = new PlayerBoardAttackerSelector(board2);

        IPlayerBoard attackingBoard = board1;
        IPlayerBoard targetsBoard = board2;
        PlayerBoardAttackerSelector attackerSelector = attackerSelector1;

        while (true)
        {
            TurnPerformingResult turnResult = PerformTurn(attackerSelector, targetsBoard);

            switch (turnResult)
            {
                case TurnPerformingResult.AttackerPasses:
                case TurnPerformingResult.PerformedNormally:
                    (attackingBoard, targetsBoard) = (targetsBoard, attackingBoard);
                    attackerSelector = (attackerSelector == attackerSelector1)
                        ? attackerSelector2
                        : attackerSelector1;
                    break;

                case TurnPerformingResult.AttackerWins:
                    return attackingBoard == board1
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
        IPlayerBoard targetsBoard)
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
