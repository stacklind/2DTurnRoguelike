using UnityEngine;

public class EndTurnStep : CombatStep
{
    public override CombatStep NextStep => CombatHandler.State.IsOver ? new EndCombatStep() : new BeginTurnStep(NextCombatant);

    public Combatant NextCombatant;

    private Combatant currentCombatant;
    public EndTurnStep(Combatant currentCombatant)
    {
        this.currentCombatant = currentCombatant;
        // - Update status effects on current combatant
        AddTask();
        // - End turn in the combat queue
        AddTask();
    }

    public override void Begin()
    {
        CombatHandler.Events.Publish(new CombatEvent.EndTurnEvent(currentCombatant, this));
    }
}
