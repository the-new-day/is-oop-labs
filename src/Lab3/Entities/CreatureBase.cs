using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public abstract class CreatureBase : ICreature
{
    public AttackPoints AttackValue { get; protected set; }

    public HealthPoints HealthValue { get; protected set; }

    public virtual bool IsAlive => !HealthValue.IsZero;

    public virtual bool CanAttack => IsAlive && !AttackValue.IsZero;

    protected CreatureBase(AttackPoints attackValue, HealthPoints healthValue)
    {
        AttackValue = attackValue;
        HealthValue = healthValue;
    }

    public virtual void Attack(ICreature otherCreature)
    {
        otherCreature.TakeDamage(AttackValue);
    }

    public virtual void TakeDamage(AttackPoints damage)
    {
        HealthValue = HealthValue.ReducedByDamage(damage);
    }

    public abstract ICreature Clone();
}
