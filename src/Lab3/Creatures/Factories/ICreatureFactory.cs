using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public interface ICreatureFactory
{
    ICreature CreateCreature(AttackPoints attackValue, HealthPoints healthValue);
}
