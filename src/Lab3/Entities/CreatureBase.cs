using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public abstract class CreatureBase : ICreature
{
    public HealthPoints AttackValue { get; protected set; }

    public HealthPoints HealthValue { get; protected set; }

    public virtual bool IsAlive => !HealthValue.IsZero;

    public virtual bool CanAttack => IsAlive && !AttackValue.IsZero;

    protected CreatureBase(HealthPoints attackValue, HealthPoints healthValue)
    {
        AttackValue = attackValue;
        HealthValue = healthValue;
    }

    public virtual void Attack(ICreature otherCreature)
    {
        otherCreature.TakeDamage(AttackValue);
    }

    public virtual void TakeDamage(HealthPoints damage)
    {
        HealthValue = (HealthValue > damage) ? (HealthValue - damage) : new HealthPoints(0);
    }

    public abstract ICreature Clone();
}
