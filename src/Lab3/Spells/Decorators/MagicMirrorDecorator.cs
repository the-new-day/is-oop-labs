using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells.Decorators;

public class MagicMirrorDecorator : CreatureDecorator
{
    public override AttackPoints AttackValue => new AttackPoints(base.HealthValue.Value);

    public override HealthPoints HealthValue => new HealthPoints(base.AttackValue.Value);

    public MagicMirrorDecorator(ICreature creature)
        : base(creature)
    {
    }

    public override MagicMirrorDecorator Clone()
    {
        return new MagicMirrorDecorator(Creature.Clone());
    }
}
