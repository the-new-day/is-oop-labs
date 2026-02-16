using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public interface ISpell
{
    ICreature GetCasted(ICreature creature);
}
