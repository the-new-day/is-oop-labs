using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.CreatureFactories;

public class ImmortalHorrorFactory : ICreatureFactory
{
    public ICreature CreateCreature()
    {
        return new ImmortalHorror(
            attackValue: new AttackPoints(4),
            healthValue: new HealthPoints(4),
            healthValueAfterRebirth: new HealthPoints(1));
    }
}
