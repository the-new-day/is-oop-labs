using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

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

    public ICreatureBuilder WithMagicShield()
    {
        _modifiers.Add(creature => new MagicShieldModifier(creature));
        return this;
    }

    public ICreatureBuilder WithAttackMastery()
    {
        _modifiers.Add(creature => new AttackMasteryModifier(creature));
        return this;
    }

    public ICreature Build()
    {
        ICreature creature = new CreatureBase(_attackValue, _healthValue);

        foreach (Func<ICreature, ICreature> modifier in _modifiers)
        {
            creature = modifier(creature);
        }

        return creature;
    }
}
