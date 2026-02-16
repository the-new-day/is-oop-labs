using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Game;

public class PlayerBoardAttackerSelector
{
    private readonly PlayerBoard _board;

    private int _currentAttackerIndex = 0;

    public PlayerBoardAttackerSelector(PlayerBoard board)
    {
        _board = board;
    }

    public ICreature? FindNextAttacker()
    {
        var attackers = _board.GetAttackers().ToList();

        if (attackers.Count == 0)
        {
            _currentAttackerIndex = 0;
            return null;
        }

        if (_currentAttackerIndex >= attackers.Count)
            _currentAttackerIndex = 0;

        ICreature attacker = attackers[_currentAttackerIndex];
        _currentAttackerIndex = (_currentAttackerIndex + 1) % attackers.Count;

        return attacker;
    }
}
