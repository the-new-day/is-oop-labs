using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.CreatureFactories;

public class BattleAnalystFactory : ICreatureFactory
{
    public ICreature CreateCreature()
    {
        return new BattleAnalyst(
            attackValue: new HealthPoints(2),
            healthValue: new HealthPoints(4),
            attackBonus: new HealthPoints(2));
    }
}
