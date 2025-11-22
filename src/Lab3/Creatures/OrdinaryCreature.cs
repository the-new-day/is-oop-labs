using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class OrdinaryCreature : CreatureBase
{
    public OrdinaryCreature(AttackPoints attackValue, HealthPoints healthValue)
        : base(attackValue, healthValue)
    {
    }

    public override OrdinaryCreature Clone()
    {
        return new OrdinaryCreature(AttackValue, HealthValue);
    }
}
