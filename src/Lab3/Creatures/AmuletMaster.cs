using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class AmuletMaster : ICreature
{
    private readonly ICreature _modifiedCreature;

    public AttackPoints AttackValue => _modifiedCreature.AttackValue;

    public HealthPoints HealthValue => _modifiedCreature.HealthValue;

    public bool IsAlive => _modifiedCreature.IsAlive;

    public bool CanAttack => _modifiedCreature.CanAttack;

    public AmuletMaster(AttackPoints attackValue, HealthPoints healthValue)
    {
        _modifiedCreature = new OrdinaryCreature(attackValue, healthValue);
        _modifiedCreature = new AttackMasteryModifier(_modifiedCreature);
        _modifiedCreature = new MagicShieldModifier(_modifiedCreature);
    }

    public void Attack(ICreature otherCreature)
    {
        _modifiedCreature.Attack(otherCreature);
    }

    public void TakeDamage(AttackPoints damage)
    {
        _modifiedCreature.TakeDamage(damage);
    }

    public AmuletMaster Clone()
    {
        return new AmuletMaster(AttackValue, HealthValue);
    }

    ICreature ICreature.Clone()
    {
        return Clone();
    }
}
