using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class ImmortalHorror : CreatureBase
{
    private readonly HealthPoints _healthValueAfterRebirth;

    private bool _wasReborned = false;

    public ImmortalHorror(AttackPoints attackValue, HealthPoints healthValue, HealthPoints healthValueAfterRebirth)
        : base(attackValue, healthValue)
    {
        _healthValueAfterRebirth = healthValueAfterRebirth;
    }

    public override void TakeDamage(AttackPoints damage)
    {
        base.TakeDamage(damage);

        if (!IsAlive && !_wasReborned)
        {
            HealthValue = _healthValueAfterRebirth;
            _wasReborned = true;
        }
    }

    public override ImmortalHorror Clone()
    {
        return new ImmortalHorror(AttackValue, HealthValue, _healthValueAfterRebirth);
    }
}
