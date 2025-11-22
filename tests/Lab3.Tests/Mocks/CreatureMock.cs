using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Mocks;

public class CreatureMock : CreatureBase
{
    public AttackPoints? LastDamageTaken { get; private set; }

    public AttackPoints TotalDamageTaken { get; private set; } = new AttackPoints(0);

    public int HitCount { get; private set; } = 0;

    public int AttackCallCount { get; private set; } = 0;

    public CreatureMock(AttackPoints attackValue, HealthPoints healthValue)
        : base(attackValue, healthValue)
    {
    }

    public override void Attack(ICreature otherCreature)
    {
        base.Attack(otherCreature);
        ++AttackCallCount;
    }

    public override void TakeDamage(AttackPoints damage)
    {
        base.TakeDamage(damage);
        LastDamageTaken = damage;
        TotalDamageTaken += damage;
        ++HitCount;
    }

    public override CreatureMock Clone()
    {
        return new CreatureMock(AttackValue, HealthValue);
    }
}
