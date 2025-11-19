using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public interface ICreatureBuilder
{
    ICreatureBuilder WithAttackMastery();

    ICreatureBuilder WithMagicShield();

    ICreature Build();
}
