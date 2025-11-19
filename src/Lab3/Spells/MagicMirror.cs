using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class MagicMirror : ISpell
{
    public ICreature GetCasted(ICreature creature)
    {
        HealthPoints oldHealthValue = creature.HealthValue;
        HealthPoints oldAttackValue = creature.AttackValue;

        creature.SetAttackValue(oldHealthValue);
        creature.SetHealthValue(oldAttackValue);

        return creature;
    }
}
