using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public class ImmortalHorrorFactory : ICreatureFactory
{
    private readonly HealthPoints _healthValueAfterRebirth;

    public ImmortalHorrorFactory(HealthPoints healthValueAfterRebirth)
    {
        _healthValueAfterRebirth = healthValueAfterRebirth;
    }

    public ICreature CreateCreature(AttackPoints attackValue, HealthPoints healthValue)
    {
        return new ImmortalHorror(attackValue, healthValue, _healthValueAfterRebirth);
    }
}
