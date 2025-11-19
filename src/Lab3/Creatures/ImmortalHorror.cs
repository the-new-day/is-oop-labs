using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class ImmortalHorror : CreatureBase
{
    private readonly HealthPoints _healthValueAfterRebirth;

    private bool _wasReborned = false;

    public ImmortalHorror(HealthPoints attackValue, HealthPoints healthValue, HealthPoints healthValueAfterRebirth)
        : base(attackValue, healthValue)
    {
        _healthValueAfterRebirth = healthValueAfterRebirth;
    }

    public override void TakeDamage(HealthPoints damage)
    {
        base.TakeDamage(damage);

        if (HealthValue.IsZero && !_wasReborned)
        {
            HealthValue = _healthValueAfterRebirth;
            _wasReborned = true;
        }
    }
}
