using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Results;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;

namespace Itmo.ObjectOrientedProgramming.Lab3.Game;

public interface IPlayerBoard
{
    PlayerBoardAddingCreatureResult AddCreature(ICreature creature);

    IEnumerable<ICreature> GetAttackers();

    IEnumerable<ICreature> GetTargets();

    void CastSpell(ISpell spell, int creatureIndex);

    IPlayerBoard Clone();
}
