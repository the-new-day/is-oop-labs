using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public interface ICreature
{
    HealthPoints HealthValue { get; }

    HealthPoints AttackValue { get; }

    bool IsAlive { get; }

    bool CanAttack { get; }

    void Attack(ICreature otherCreature);

    void TakeDamage(HealthPoints damage);

    ICreature Clone();
}
