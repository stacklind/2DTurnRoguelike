using System;

public class TriggeredStatusEffectInstance : StatusEffectInstance
{
    private TriggeredStatusEffect statusEffect;

    public Type TriggerEventType { get; }
    public Delegate TriggerHandler { get; }

    public TriggeredStatusEffectInstance(TriggeredStatusEffect statusEffect, Combatant user, Combatant target) : base(statusEffect, user, target)
    {
        this.statusEffect = statusEffect;
        (TriggerEventType, TriggerHandler) = statusEffect.InitializeTriggers(this);
        statusEffect.EnableTrigger(this);
    }

    public void Trigger()
    {
        foreach (IStatusEffectBehaviour seb in statusEffectBehaviours)
        {
            seb.OnTick();
        }
        
        Stacks--;
    }

    protected override void Remove()
    {
        statusEffect.DisableTrigger(this);
        base.Remove();
    }
}
