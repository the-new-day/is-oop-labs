using Itmo.ObjectOrientedProgramming.Lab3.CreatureFactories;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Results;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;

namespace Itmo.ObjectOrientedProgramming.Lab3.Game;

public class PlayerBoard
{
    private readonly int _maxCreaturesCount;

    private readonly List<ICreature> _creatures = new();

    public PlayerBoard(int maxCreaturesCount)
    {
        if (maxCreaturesCount < 0)
            throw new ArgumentException("maxCreaturesCount can't be negative", nameof(maxCreaturesCount));

        _maxCreaturesCount = maxCreaturesCount;
    }

    public PlayerBoardAddingCreatureResult AddCreature(ICreatureFactory factory)
    {
        if (_creatures.Count == _maxCreaturesCount)
            return new PlayerBoardAddingCreatureResult.CreatureLimitExceeded(_maxCreaturesCount);

        ICreature creature = factory.CreateCreature();

        _creatures.Add(creature);
        return new PlayerBoardAddingCreatureResult.Success(_creatures.Count - 1);
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
        return _creatures.Where(creature => !creature.HealthValue.IsZero && !creature.AttackValue.IsZero);
    }

    public IEnumerable<ICreature> GetTargets()
    {
        return _creatures.Where(creature => !creature.HealthValue.IsZero);
    }
}
