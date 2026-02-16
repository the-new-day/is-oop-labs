using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;

namespace Itmo.ObjectOrientedProgramming.Lab3.Game;

public class PlayerBoard
{
    private readonly List<ICreature> _creatures;

    public PlayerBoard(IEnumerable<ICreature> creatures)
    {
        _creatures = creatures.ToList();
    }

    public void CastSpell(ISpell spell, int creatureIndex)
    {
        if (creatureIndex < 0 || creatureIndex >= _creatures.Count)
            throw new ArgumentOutOfRangeException(nameof(creatureIndex), $"Index {creatureIndex} is out of range");

        ICreature oldCreature = _creatures[creatureIndex];
        ICreature newCreature = spell.GetCasted(oldCreature);
        _creatures[creatureIndex] = newCreature;
    }

    public IEnumerable<ICreature> GetAttackers()
    {
        return _creatures
            .Where(creature => !creature.HealthValue.IsZero && !creature.AttackValue.IsZero);
    }

    public IEnumerable<ICreature> GetTargets()
    {
        return _creatures
            .Where(creature => !creature.HealthValue.IsZero);
    }

    public PlayerBoard Clone()
    {
        var creatures = _creatures.Select(creature => creature.Clone()).ToList();
        var board = new PlayerBoard(creatures);

        return board;
    }
}
