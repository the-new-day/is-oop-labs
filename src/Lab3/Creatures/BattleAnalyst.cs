using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class BattleAnalyst : CreatureBase
{
    private readonly AttackPoints _attackBonus;

    public BattleAnalyst(AttackPoints attackValue, HealthPoints healthValue, AttackPoints attackBonus)
        : base(attackValue, healthValue)
    {
        _attackBonus = attackBonus;
    }

    public override void Attack(ICreature otherCreature)
    {
        AttackValue += _attackBonus;
        base.Attack(otherCreature);
    }

    public override BattleAnalyst Clone()
    {
        return new BattleAnalyst(AttackValue, HealthValue, _attackBonus);
    }
}
