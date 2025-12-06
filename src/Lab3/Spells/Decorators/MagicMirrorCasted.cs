using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells.Decorators;

public class MagicMirrorCasted : CreatureDecorator
{
    public override AttackPoints AttackValue => new AttackPoints(base.HealthValue.Value);

    public override HealthPoints HealthValue => new HealthPoints(base.AttackValue.Value);

    public MagicMirrorCasted(ICreature creature)
        : base(creature)
    {
    }

    public override MagicMirrorCasted Clone()
    {
        return new MagicMirrorCasted(Creature.Clone());
    }
}
