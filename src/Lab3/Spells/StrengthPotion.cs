using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Spells.Decorators;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class StrengthPotion : ISpell
{
    private readonly HealthPoints _attackBonus;

    public StrengthPotion(HealthPoints attackBonus)
    {
        _attackBonus = attackBonus;
    }

    public ICreature GetCasted(ICreature creature)
    {
        return new StrengthPotionDecorator(creature, _attackBonus);
    }
}
