using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells.Decorators;

public class EndurancePotionCasted : CreatureDecorator
{
    private readonly HealthPoints _healthBonus;

    public override HealthPoints HealthValue => base.HealthValue + _healthBonus;

    public EndurancePotionCasted(ICreature creature, HealthPoints healthBonus)
        : base(creature)
    {
        _healthBonus = healthBonus;
    }

    public override EndurancePotionCasted Clone()
    {
        return new EndurancePotionCasted(Creature.Clone(), _healthBonus);
    }
}
