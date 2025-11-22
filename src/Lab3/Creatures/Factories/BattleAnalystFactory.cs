using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public class BattleAnalystFactory : ICreatureFactory
{
    private readonly AttackPoints _attackBonus;

    public BattleAnalystFactory(AttackPoints attackBonus)
    {
        _attackBonus = attackBonus;
    }

    public ICreature CreateCreature(AttackPoints attackValue, HealthPoints healthValue)
    {
        return new BattleAnalyst(attackValue, healthValue, _attackBonus);
    }
}
