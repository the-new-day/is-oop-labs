using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public interface ICreatureBuilder
{
    ICreatureBuilder WithHealth(HealthPoints healthValue);

    ICreatureBuilder WithAttack(AttackPoints attackValue);

    ICreatureBuilder WithModifier(ICreatureModifierFactory modifierFactory);

    ICreature Build();
}
