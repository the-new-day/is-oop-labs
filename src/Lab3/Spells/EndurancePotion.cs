using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Spells.Decorators;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class EndurancePotion : ISpell
{
    private readonly HealthPoints _healthBonus;

    public EndurancePotion(HealthPoints healthBonus)
    {
        _healthBonus = healthBonus;
    }

    public ICreature GetCasted(ICreature creature)
    {
        return new EndurancePotionCasted(creature, _healthBonus);
    }
}
