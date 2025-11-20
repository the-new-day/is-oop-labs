using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Spells.Decorators;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class MagicMirror : ISpell
{
    public ICreature GetCasted(ICreature creature)
    {
        return new MagicMirrorDecorator(creature);
    }
}
