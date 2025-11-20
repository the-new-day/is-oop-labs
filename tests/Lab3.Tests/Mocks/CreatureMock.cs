using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Mocks;

public class CreatureMock : CreatureBase
{
    public HealthPoints? LastDamageTaken { get; private set; }

    public HealthPoints TotalDamageTaken { get; private set; } = new HealthPoints(0);

    public int HitCount { get; private set; } = 0;

    public CreatureMock(HealthPoints attackValue, HealthPoints healthValue)
        : base(attackValue, healthValue)
    {
    }

    public override void TakeDamage(HealthPoints damage)
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
