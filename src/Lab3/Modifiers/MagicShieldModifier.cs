using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public class MagicShieldModifier : CreatureDecorator
{
    private bool _isShieldActive = true;

    public MagicShieldModifier(ICreature creature)
        : base(creature)
    {
    }

    public override void TakeDamage(AttackPoints damage)
    {
        if (_isShieldActive)
        {
            _isShieldActive = false;
            return;
        }

        base.TakeDamage(damage);
    }

    public override MagicShieldModifier Clone()
    {
        return new MagicShieldModifier(Creature.Clone())
        {
            _isShieldActive = _isShieldActive,
        };
    }
}
