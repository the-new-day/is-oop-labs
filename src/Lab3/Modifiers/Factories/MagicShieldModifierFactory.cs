using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Factories;

public class MagicShieldModifierFactory : ICreatureModifierFactory
{
    public ICreature ApplyTo(ICreature creature)
    {
        return new MagicShieldModifier(creature);
    }
}
