using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public class MagicShield : CreatureModifier
{
    private bool _isShieldActive = true;

    public MagicShield(ICreature creature) : base(creature)
    {
    }

    public override void TakeDamage(HealthPoints damage)
    {
        if (_isShieldActive)
        {
            _isShieldActive = false;
            return;
        }

        base.TakeDamage(damage);
    }
}
