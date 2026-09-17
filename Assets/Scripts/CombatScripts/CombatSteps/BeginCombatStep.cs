using UnityEngine;

public class BeginCombatStep : CombatStep
{
    public override CombatStep NextStep => new BeginTurnStep(StartingCombatant);

    public Combatant StartingCombatant;
    
    public BeginCombatStep()
    {
        // Checklist:
        // - Initialize combatants
        AddTask();
        // - Start playing music
        AddTask();
        //
        // Total: 2
    }

    public override void Begin()
    {
        CombatHandler.Events.Publish(new CombatEvent.BeginCombatEvent(this));
    }
}
