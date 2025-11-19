using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class ViciousFighter : CreatureBase
{
    private readonly int _multiplier;

    public ViciousFighter(HealthPoints attackValue, HealthPoints healthValue, int multiplier)
        : base(attackValue, healthValue)
    {
        _multiplier = multiplier;
    }

    public override void TakeDamage(HealthPoints damage)
    {
        base.TakeDamage(damage);

        if (!HealthValue.IsZero)
        {
            AttackValue = AttackValue.MultipliedBy(_multiplier);
        }
    }
}
