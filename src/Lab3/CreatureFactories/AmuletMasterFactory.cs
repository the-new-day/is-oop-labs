using Itmo.ObjectOrientedProgramming.Lab3.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.CreatureFactories;

public class AmuletMasterFactory : ICreatureFactory
{
    public ICreature CreateCreature()
    {
        return new CreatureBuilder(new HealthPoints(5), new HealthPoints(2))
            .WithAttackMastery()
            .WithMagicShield()
            .Build();
    }
}
