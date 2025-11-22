using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.CreatureFactories;

public class MimicChestFactory : ICreatureFactory
{
    public ICreature CreateCreature()
    {
        return new MimicChest(
            attackValue: new AttackPoints(1),
            healthValue: new HealthPoints(1));
    }
}
