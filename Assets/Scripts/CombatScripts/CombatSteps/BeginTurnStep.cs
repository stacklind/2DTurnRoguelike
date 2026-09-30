using UnityEngine;

public class BeginTurnStep : CombatStep
{
    public override CombatStep NextStep => new PerformAbilityStep(ability, combatant, targets);

    private Ability ability;
    private Combatant combatant;
    private Combatant[] targets;

    public BeginTurnStep(Combatant currentCombatant)
    {
        combatant = currentCombatant;

        //  - Ability chosen
        AddTask();
    }

    public override void Begin()
    {
        CombatHandler.Events.Subscribe<CombatEvent.AbilityActivatedEvent>(OnAbilityActivated);
        CombatHandler.Events.Publish(new CombatEvent.BeginTurnEvent(combatant, this));
    }

    private void OnAbilityActivated(CombatEvent.AbilityActivatedEvent evt)
    {
        CombatHandler.Events.Unsubscribe<CombatEvent.AbilityActivatedEvent>(OnAbilityActivated);

        ability = evt.Ability;
        targets = evt.Targets;

        CompleteTask();
    }
}
