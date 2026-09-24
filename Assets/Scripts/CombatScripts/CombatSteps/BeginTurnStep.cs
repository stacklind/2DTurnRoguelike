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

        //  - CombatantInfo updated
        AddTask();
        //  - MoveButtons updated
        AddTask();
        //  - Move chosen
        AddTask();
    }

    public override void Begin()
    {
        Debug.Log("BeginTurnStep > Begin");
        CombatHandler.Events.Subscribe<CombatEvent.AbilityActivatedEvent>(OnAbilityChosen);
        CombatHandler.Events.Publish(new CombatEvent.BeginTurnEvent(combatant, this));
    }

    private void OnAbilityChosen(CombatEvent.AbilityActivatedEvent evt)
    {
        Debug.Log("BeginTurnStep > OnAbilityChosen");
        CombatHandler.Events.Unsubscribe<CombatEvent.AbilityActivatedEvent>(OnAbilityChosen);

        ability = evt.Ability;
        combatant = evt.User;
        targets = evt.Targets;

        CompleteTask();
    }
}
