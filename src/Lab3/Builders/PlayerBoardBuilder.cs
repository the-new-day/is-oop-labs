using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Game;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class PlayerBoardBuilder : IPlayerBoardBuilder
{
    private readonly List<ICreature> _creatures = new();

    private readonly int _maxCreaturesCount;

    public PlayerBoardBuilder(int maxCreaturesCount)
    {
        if (maxCreaturesCount < 0)
            throw new ArgumentException("maxCreaturesCount can't be negative", nameof(maxCreaturesCount));

        _maxCreaturesCount = maxCreaturesCount;
    }

    public PlayerBoard Build()
    {
        return new PlayerBoard(_creatures);
    }

    public IPlayerBoardBuilder WithCreature(ICreature creature)
    {
        if (_creatures.Count == _maxCreaturesCount)
            throw new InvalidOperationException("Creatures count exceeded");

        _creatures.Add(creature.Clone());
        return this;
    }
}
