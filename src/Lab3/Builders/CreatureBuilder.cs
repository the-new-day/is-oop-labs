using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class CreatureBuilder : ICreatureBuilder
{
    private readonly List<ICreatureModifierFactory> _modifiers = new();

    private readonly ICreatureFactory _creatureFactory;

    private AttackPoints _attackValue;

    private HealthPoints _healthValue;

    public CreatureBuilder(ICreatureFactory creatureFactory)
    {
        _creatureFactory = creatureFactory;
    }

    public ICreatureBuilder WithHealth(HealthPoints healthValue)
    {
        _healthValue = healthValue;
        return this;
    }

    public ICreatureBuilder WithAttack(AttackPoints attackValue)
    {
        _attackValue = attackValue;
        return this;
    }

    public ICreatureBuilder WithModifier(ICreatureModifierFactory modifierFactory)
    {
        _modifiers.Add(modifierFactory);
        return this;
    }

    public ICreature Build()
    {
        ICreature creature = _creatureFactory.CreateCreature(_attackValue, _healthValue);

        foreach (ICreatureModifierFactory factory in _modifiers)
        {
            creature = factory.ApplyTo(creature);
        }

        return creature;
    }
}
