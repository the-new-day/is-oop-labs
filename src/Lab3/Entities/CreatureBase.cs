using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class CreatureBase : ICreature
{
    public HealthPoints AttackValue { get; protected set; }

    public HealthPoints HealthValue { get; protected set; }

    public CreatureBase(HealthPoints attackValue, HealthPoints healthValue)
    {
        AttackValue = attackValue;
        HealthValue = healthValue;
    }

    public virtual void Attack(ICreature otherCreature)
    {
        if (!HealthValue.IsZero && !AttackValue.IsZero)
            otherCreature.TakeDamage(AttackValue);
    }

    public virtual void TakeDamage(HealthPoints damage)
    {
        if (!HealthValue.IsZero)
            HealthValue = (HealthValue > damage) ? (HealthValue - damage) : new HealthPoints(0);
    }

    public virtual void SetAttackValue(HealthPoints newValue)
    {
        AttackValue = newValue;
    }

    public virtual void SetHealthValue(HealthPoints newValue)
    {
        HealthValue = newValue;
    }
}
