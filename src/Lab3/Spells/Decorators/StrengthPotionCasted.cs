using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells.Decorators;

public class StrengthPotionCasted : CreatureDecorator
{
    private readonly AttackPoints _attackBonus;

    public override AttackPoints AttackValue => base.AttackValue + _attackBonus;

    public StrengthPotionCasted(ICreature creature, AttackPoints attackBonus)
        : base(creature)
    {
        _attackBonus = attackBonus;
    }

    public override StrengthPotionCasted Clone()
    {
        return new StrengthPotionCasted(Creature.Clone(), _attackBonus);
    }
}
