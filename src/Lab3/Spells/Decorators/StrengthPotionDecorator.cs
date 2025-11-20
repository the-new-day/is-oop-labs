using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells.Decorators;

public class StrengthPotionDecorator : CreatureDecorator
{
    private readonly HealthPoints _attackBonus;

    public override HealthPoints AttackValue => base.AttackValue + _attackBonus;

    public StrengthPotionDecorator(ICreature creature, HealthPoints attackBonus)
        : base(creature)
    {
        _attackBonus = attackBonus;
    }

    public override StrengthPotionDecorator Clone()
    {
        return new StrengthPotionDecorator(Creature.Clone(), _attackBonus);
    }
}
