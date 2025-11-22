using Itmo.ObjectOrientedProgramming.Lab3.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Directors;

public class BattleAnalystDirector : ICreatureDirector
{
    public ICreatureBuilder Direct(ICreatureBuilder builder)
    {
        return builder
            .WithAttack(new AttackPoints(2))
            .WithHealth(new HealthPoints(4));
    }
}
