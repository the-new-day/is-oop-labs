using Itmo.ObjectOrientedProgramming.Lab3.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Directors;

public class AmuletMasterDirector : ICreatureDirector
{
    public ICreatureBuilder Direct(ICreatureBuilder builder)
    {
        return builder
            .WithAttack(new AttackPoints(5))
            .WithHealth(new HealthPoints(2))
            .WithModifier(new MagicShieldModifierFactory())
            .WithModifier(new AttackMasteryModifierFactory());
    }
}
