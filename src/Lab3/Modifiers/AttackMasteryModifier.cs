using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public class AttackMasteryModifier : CreatureModifier
{
    public AttackMasteryModifier(ICreature creature)
        : base(creature)
    {
    }

    public override void Attack(ICreature otherCreature)
    {
        base.Attack(otherCreature);
        base.Attack(otherCreature);
    }
}
