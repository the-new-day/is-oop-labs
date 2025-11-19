using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public abstract class CreatureModifier : ICreature
{
    public virtual HealthPoints AttackValue
    {
        get => _creature.AttackValue;
        set => _creature.AttackValue = value;
    }

    public virtual HealthPoints HealthValue
    {
        get => _creature.HealthValue;
        set => _creature.HealthValue = value;
    }

    private readonly ICreature _creature;

    protected CreatureModifier(ICreature creature)
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
}
