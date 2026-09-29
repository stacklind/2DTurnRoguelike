using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Status Effects/Sneak")]
public class StatusEffect_Sneak : TriggeredStatusEffect
{
    public override IStatusEffectBehaviour[] StatusEffectBehaviours => new IStatusEffectBehaviour[] { 
        new UntargetableSEBehaviour(), 
        new AlwaysCritSEBehaviour() };

    public override (Type, Delegate) InitializeTriggers(TriggeredStatusEffectInstance instance)
    {
        Type t = typeof(CombatEvent.DamageEvent);
        Action<CombatEvent.DamageEvent> handler = e => HandleDamageEvent(e, instance);
        return (t, handler);
    }

    private void HandleDamageEvent(CombatEvent.DamageEvent evt, TriggeredStatusEffectInstance instance)
    {
        if(evt.Source == instance.AppliedTo)
        {
            instance.Trigger();
        }
    }
}
