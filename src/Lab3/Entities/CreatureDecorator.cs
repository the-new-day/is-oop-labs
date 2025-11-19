using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public abstract class CreatureDecorator : ICreature
{
    public virtual HealthPoints AttackValue => _creature.AttackValue;

    public virtual HealthPoints HealthValue => _creature.HealthValue;

    private readonly ICreature _creature;

    protected CreatureDecorator(ICreature creature)
    {
        _creature = creature;
    }

    public virtual void Attack(ICreature otherCreature)
    {
        _creature.Attack(otherCreature);
    }

    public virtual void TakeDamage(HealthPoints damage)
    {
        _creature.TakeDamage(damage);
    }

    public virtual void SetAttackValue(HealthPoints newValue)
    {
        _creature.SetAttackValue(newValue);
    }

    public virtual void SetHealthValue(HealthPoints newValue)
    {
        _creature.SetHealthValue(newValue);
    }
}
