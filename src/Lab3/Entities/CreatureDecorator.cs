using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public abstract class CreatureDecorator : ICreature
{
    public virtual HealthPoints AttackValue => Creature.AttackValue;

    public virtual HealthPoints HealthValue => Creature.HealthValue;

    public virtual bool IsAlive => !HealthValue.IsZero;

    public virtual bool CanAttack => IsAlive && !AttackValue.IsZero;

    protected ICreature Creature { get; }

    protected CreatureDecorator(ICreature creature)
    {
        Creature = creature;
    }

    public virtual void Attack(ICreature otherCreature)
    {
        Creature.Attack(otherCreature);
    }

    public virtual void TakeDamage(HealthPoints damage)
    {
        Creature.TakeDamage(damage);
    }

    public abstract ICreature Clone();
}
