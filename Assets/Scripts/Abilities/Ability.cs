using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public string Name;

    public TargetingComponent TargetingComponent;
    public IEffectComponent[] EffectComponents;

    public void Select(Combatant user)
    {
        Debug.Log("Ability > Select");
        CombatHandler.Events.Subscribe<CombatEvent.TargetsAquiredEvent>(HandleTargetsAquiredEvent);
        TargetingComponent.AquireTargets(user);
    }

    public virtual void ApplyEffects(Combatant user, Combatant[] targets)
    {
        Debug.Log("Ability > ApplyEffects");
        foreach (Combatant target in targets)
        {
            foreach (IEffectComponent e in EffectComponents)
            {
                e.ApplyEffect(user, target);
            }
        }
    }

    private void HandleTargetsAquiredEvent(CombatEvent.TargetsAquiredEvent evt)
    {
        Debug.Log("Ability > HandleTargetsAquiredEvent");
        CombatHandler.Events.Unsubscribe<CombatEvent.TargetsAquiredEvent>(HandleTargetsAquiredEvent);
        CombatHandler.Events.Publish(new CombatEvent.AbilityActivatedEvent(this, evt.User, evt.Targets));
    }

    public abstract string GetTooltip(Combatant user);
}
