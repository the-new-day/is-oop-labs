using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class CreatureBase : ICreature
{
    public HealthPoints AttackValue { get; set; }

    public HealthPoints HealthValue { get; set; }

    public bool IsAlive => !HealthValue.IsZero;

    public bool CanAttack => !AttackValue.IsZero;

    public CreatureBase(HealthPoints attackValue, HealthPoints healthValue)
    {
        AttackValue = attackValue;
        HealthValue = healthValue;
    }

    public virtual void Attack(ICreature otherCreature)
    {
        if (IsAlive && CanAttack)
            otherCreature.TakeDamage(AttackValue);
    }

    public virtual void TakeDamage(HealthPoints damage)
    {
        if (damage.IsZero)
            return;

        HealthValue = (HealthValue > damage) ? (HealthValue - damage) : new HealthPoints(0);
    }
}
