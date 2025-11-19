using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public interface ICreature
{
    HealthPoints HealthValue { get; set; }

    HealthPoints AttackValue { get; set; }

    void Attack(ICreature otherCreature);

    void TakeDamage(HealthPoints damage);
}
