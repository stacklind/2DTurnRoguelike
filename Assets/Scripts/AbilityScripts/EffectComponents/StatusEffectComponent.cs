using UnityEngine;

public class StatusEffectComponent : IEffectComponent
{
    private StatusEffect statusEffect;

    public StatusEffectComponent(StatusEffect statusEffect)
    {
        this.statusEffect = statusEffect;
    }

    public void ApplyEffect(Combatant user, Combatant target)
    {
        StatusEffectInstance instance;
        if (statusEffect is TriggeredStatusEffect)
        {
            instance = new TriggeredStatusEffectInstance(statusEffect as TriggeredStatusEffect, user, target);
            
        }
        else
        {
            instance = new TimedStatusEffectInstance(statusEffect, user, target);
        }

        if (statusEffect.IsBuff)
        {
            target.ApplyBuff(instance);
        }
        else
        {
            target.ApplyDebuff(instance);
        }
    }
}
