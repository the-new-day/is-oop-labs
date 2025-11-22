using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.CreatureFactories;

public class ViciousFighterFactory : ICreatureFactory
{
    public ICreature CreateCreature()
    {
        return new ViciousFighter(
            attackValue: new AttackPoints(1),
            healthValue: new HealthPoints(6),
            multiplier: 2);
    }
}
