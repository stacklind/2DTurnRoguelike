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
    }

    public override void Begin()
    {
        // Do stuff that requires animations and wait for the animations to finish before being ready for next step.
        //foreach(IEffectComponent ec in ability.EffectComponents)
        //{
        //    if (ec is DamageEffectComponent)
        //    {
        //        CombatHandler.Events.Subscribe<CombatEvent.DamageEvent>(OnDamageHandled);
        //    }
        //}

        ability.ApplyEffects(combatant, targets);
    }

    private void OnDamageHandled(CombatEvent.DamageEvent evt)
    {
        CombatHandler.Events.Unsubscribe<CombatEvent.DamageEvent>(OnDamageHandled);
    }
}
