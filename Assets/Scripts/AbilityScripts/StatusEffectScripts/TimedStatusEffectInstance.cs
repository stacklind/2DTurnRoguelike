using UnityEngine;

public class TimedStatusEffectInstance : StatusEffectInstance
{
    public TimedStatusEffectInstance(StatusEffect statusEffect, Combatant user, Combatant target) : base(statusEffect, user, target) { }

    public void Tick(int stacksToReduce)
    {
        Stacks -= stacksToReduce;
        foreach (IStatusEffectBehaviour sec in statusEffectBehaviours)
        {
            sec.OnTick();
        }
    }
}
