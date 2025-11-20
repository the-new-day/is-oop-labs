using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class ViciousFighter : CreatureBase
{
    private readonly int _multiplier;

    public ViciousFighter(HealthPoints attackValue, HealthPoints healthValue, int multiplier)
        : base(attackValue, healthValue)
    {
        if (multiplier < 0)
            throw new ArgumentException("multiplier can't be negative", nameof(multiplier));

        _multiplier = multiplier;
    }

    public override void TakeDamage(HealthPoints damage)
    {
        base.TakeDamage(damage);

        if (IsAlive)
        {
            AttackValue = AttackValue.MultipliedBy(_multiplier);
        }
    }

    public override ViciousFighter Clone()
    {
        return new ViciousFighter(AttackValue, HealthValue, _multiplier);
    }
}
