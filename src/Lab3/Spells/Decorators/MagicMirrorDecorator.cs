using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells.Decorators;

public class MagicMirrorDecorator : CreatureDecorator
{
    public override HealthPoints HealthValue => base.AttackValue;

    public override HealthPoints AttackValue => base.HealthValue;

    public MagicMirrorDecorator(ICreature creature)
        : base(creature)
    {
    }

    public override MagicMirrorDecorator Clone()
    {
        return new MagicMirrorDecorator(Creature.Clone());
    }
}
