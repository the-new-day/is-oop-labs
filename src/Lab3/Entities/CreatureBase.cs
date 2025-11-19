using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public abstract class CreatureBase : ICreature
{
    public HealthPoints HealthValue { get; set; }

    public HealthPoints AttackValue { get; set; }

    protected CreatureBase(HealthPoints healthValue, HealthPoints attackValue)
    {
        HealthValue = healthValue;
        AttackValue = attackValue;
    }

    public virtual void Attack(ICreature otherCreature)
    {
        if (HealthValue.IsZero)
            return; // TODO: error? exception?

        otherCreature.TakeDamage(AttackValue);
    }

    public virtual void TakeDamage(HealthPoints damage)
    {
        if (damage.IsZero)
            return;

        HealthValue = (HealthValue > damage) ? (HealthValue - damage) : new HealthPoints(0);
    }
}
