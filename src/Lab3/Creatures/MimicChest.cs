using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class MimicChest : CreatureBase
{
    public MimicChest(AttackPoints attackValue, HealthPoints healthValue)
        : base(attackValue, healthValue)
    {
    }

    public override void Attack(ICreature otherCreature)
    {
        AttackValue = AttackPoints.Max(AttackValue, otherCreature.AttackValue);
        HealthValue = HealthPoints.Max(HealthValue, otherCreature.HealthValue);

        base.Attack(otherCreature);
    }

    public override MimicChest Clone()
    {
        return new MimicChest(AttackValue, HealthValue);
    }
}
