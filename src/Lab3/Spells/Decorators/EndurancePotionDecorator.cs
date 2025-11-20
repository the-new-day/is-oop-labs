using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells.Decorators;

public class EndurancePotionDecorator : CreatureDecorator
{
    private readonly HealthPoints _healthBonus;

    public override HealthPoints HealthValue => base.HealthValue + _healthBonus;

    public EndurancePotionDecorator(ICreature creature, HealthPoints healthBonus)
        : base(creature)
    {
        _healthBonus = healthBonus;
    }

    public override EndurancePotionDecorator Clone()
    {
        return new EndurancePotionDecorator(Creature.Clone(), _healthBonus);
    }
}
