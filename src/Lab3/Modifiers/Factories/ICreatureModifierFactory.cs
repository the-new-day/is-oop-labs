using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Factories;

public interface ICreatureModifierFactory
{
    ICreature ApplyTo(ICreature creature);
}
