using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.CreatureFactories;

public interface ICreatureFactory
{
    ICreature CreateCreature();
}
