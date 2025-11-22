using Itmo.ObjectOrientedProgramming.Lab3.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.CreatureFactories;

public class AmuletMasterFactory : ICreatureFactory
{
    public ICreature CreateCreature()
    {
        return new CreatureBuilder(new HealthPoints(5), new HealthPoints(2))
            .WithModifier(creature => new AttackMasteryModifier(creature))
            .WithModifier(creature => new MagicShieldModifier(creature))
            .Build();
    }
}
