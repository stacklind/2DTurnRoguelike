using UnityEngine;

public class UpdateBattlefieldStep : CombatStep
{
    public override CombatStep NextStep => new EndTurnStep(combatant);

    private Ability ability;
    private Combatant combatant;
    private Combatant[] targets;

    public UpdateBattlefieldStep(Ability ability, Combatant user, Combatant[] targets)
    {
        this.ability = ability;
        this.combatant = user;
        this.targets = targets;

        
        // Checklist size will depend on the move, calculated in Begin()
    }

    public override void Begin()
    {
        Debug.Log("UpdateBattlefieldStep > Begin");
        foreach(IEffectComponent ec in ability.EffectComponents)
        {
            if (ec is DamageEffectComponent)
            {
                CombatHandler.Events.Subscribe<CombatEvent.DamageEvent>(OnDamageHandled);
            }
        }

        ability.ApplyEffects(combatant, targets);
    }

    private void OnDamageHandled(CombatEvent.DamageEvent evt)
    {
        Debug.Log("UpdateBattlefieldStep > OnDamagehandled");
        CombatHandler.Events.Unsubscribe<CombatEvent.DamageEvent>(OnDamageHandled);

        if(evt.Died)
        {
            AddTask();
            CombatHandler.Events.Publish(new CombatEvent.DeathEvent(evt.Target, this));
        }
    }
}
