using UnityEngine;

public class BeginTurnStep : CombatStep
{
    public override CombatStep NextStep => new PerformMoveStep(Move, combatant);

    public Move Move;

    private Combatant combatant;

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
        CombatHandler.Events.Subscribe<CombatEvent.MoveChosenEvent>(OnMoveChosen);
        CombatHandler.Events.Publish(new CombatEvent.BeginTurnEvent(combatant, this));
    }

    private void OnMoveChosen(CombatEvent.MoveChosenEvent evt)
    {
        CombatHandler.Events.Unsubscribe<CombatEvent.MoveChosenEvent>(OnMoveChosen);
        Move = evt.Move;
        CompleteTask();
    }
}
