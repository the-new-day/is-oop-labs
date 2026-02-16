using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Mocks;

public class SpellMock : ISpell
{
    public ICreature? LastTarget { get; private set; }

    public ICreature GetCasted(ICreature creature)
    {
        LastTarget = creature;
        return creature;
    }
}
