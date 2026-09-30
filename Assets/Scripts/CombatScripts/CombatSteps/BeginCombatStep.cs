using UnityEngine;

public class BeginCombatStep : CombatStep
{
    public override CombatStep NextStep => new BeginTurnStep(StartingCombatant);

    public Combatant StartingCombatant;
    
    public BeginCombatStep()
    {

    }

    public override void Begin()
    {
        CombatHandler.Events.Publish(new CombatEvent.BeginCombatEvent(this));
    }
}
