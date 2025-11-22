using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public class AmuletMasterFactory : ICreatureFactory
{
    public ICreature CreateCreature(AttackPoints attackValue, HealthPoints healthValue)
    {
        return new AmuletMaster(attackValue, healthValue);
    }
}
