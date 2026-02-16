using Itmo.ObjectOrientedProgramming.Lab3.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Directors;

public class ViciousFighterDirector : ICreatureDirector
{
    public ICreatureBuilder Direct(ICreatureBuilder builder)
    {
        return builder
            .WithAttack(new AttackPoints(1))
            .WithHealth(new HealthPoints(6));
    }
}
