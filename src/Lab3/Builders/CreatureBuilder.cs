using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class CreatureBuilder : ICreatureBuilder
{
    private readonly List<Func<ICreature, ICreature>> _modifiers = new();

    private readonly HealthPoints _attackValue;

    private readonly HealthPoints _healthValue;

    public CreatureBuilder(HealthPoints attackValue, HealthPoints healthValue)
    {
        _attackValue = attackValue;
        _healthValue = healthValue;
    }

    public ICreatureBuilder WithModifier(Func<ICreature, ICreature> modifierFactory)
    {
        _modifiers.Add(modifierFactory);
        return this;
    }

    public ICreature Build()
    {
        ICreature creature = new OrdinaryCreature(_attackValue, _healthValue);
        return _modifiers.Aggregate(creature, (current, modifier) => modifier(current));
    }
}
