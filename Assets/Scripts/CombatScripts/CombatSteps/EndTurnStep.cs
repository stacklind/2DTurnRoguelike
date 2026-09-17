using UnityEngine;

public class EndTurnStep : CombatStep
{
    public override CombatStep NextStep => CombatHandler.State.IsOver ? new EndCombatStep() : new BeginTurnStep(nextCombatant);

    public Combatant nextCombatant;
    public EndTurnStep()
    {
        // - End turn in the combat queue
        AddTask();
    }

    public override void Begin()
    {
        CombatHandler.Events.Publish(new CombatEvent.EndTurnEvent(this));
    }
}
