using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Game;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public interface IPlayerBoardBuilder
{
    IPlayerBoardBuilder WithCreature(ICreature creature);

    PlayerBoard Build();
}
