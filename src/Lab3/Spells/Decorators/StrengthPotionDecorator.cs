using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells.Decorators;

public class StrengthPotionDecorator : CreatureDecorator
{
    private readonly AttackPoints _attackBonus;

    public override AttackPoints AttackValue => base.AttackValue + _attackBonus;

    public StrengthPotionDecorator(ICreature creature, AttackPoints attackBonus)
        : base(creature)
    {
        _attackBonus = attackBonus;
    }

    public override StrengthPotionDecorator Clone()
    {
        return new StrengthPotionDecorator(Creature.Clone(), _attackBonus);
    }
}
