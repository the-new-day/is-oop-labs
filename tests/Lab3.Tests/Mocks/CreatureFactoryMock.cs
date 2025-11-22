using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Mocks;

public class CreatureFactoryMock : ICreatureFactory
{
    public ICreature CreateCreature(AttackPoints attackValue, HealthPoints healthValue)
    {
        return new CreatureMock(attackValue, healthValue);
    }
}
