using System;

public abstract class TriggeredStatusEffect : StatusEffect
{
    public abstract (Type, Delegate) InitializeTriggers(TriggeredStatusEffectInstance instance);

    public void EnableTrigger(TriggeredStatusEffectInstance instance)
    {
        CombatHandler.Events.Subscribe(instance.TriggerEventType, instance.TriggerHandler);
    }

    public void DisableTrigger(TriggeredStatusEffectInstance instance)
    {
        CombatHandler.Events.Unsubscribe(instance.TriggerEventType, instance.TriggerHandler);
    }
}
