using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public class ViciousFighterFactory : ICreatureFactory
{
    private readonly int _multiplier;

    public ViciousFighterFactory(int multiplier)
    {
        _multiplier = multiplier;
    }

    public ICreature CreateCreature(AttackPoints attackValue, HealthPoints healthValue)
    {
        return new ViciousFighter(attackValue, healthValue, _multiplier);
    }
}
