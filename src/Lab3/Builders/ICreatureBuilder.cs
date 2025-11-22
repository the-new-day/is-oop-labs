using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public interface ICreatureBuilder
{
    ICreatureBuilder WithModifier(Func<ICreature, ICreature> modifierFactory);

    ICreature Build();
}
