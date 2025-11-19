using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class ProtectionAmulet : ISpell
{
    public ICreature GetCasted(ICreature creature)
    {
        return new MagicShieldModifier(creature);
    }
}
