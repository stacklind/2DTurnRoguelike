using UnityEngine;

public class PerformAbilityStep : CombatStep
{
    public override CombatStep NextStep => new UpdateBattlefieldStep(Ability, User, Targets);

    public Combatant User;
    public Ability Ability;
    public Combatant[] Targets;

    public PerformAbilityStep(Ability ability, Combatant user, Combatant[] targets)
    {
        Ability = ability;
        User = user;
        Targets = targets;

        // Checklist
        //  - Play animation
        AddTask();
        //  - Play sound
        AddTask();
    }

    public override void Begin()
    {
        CombatHandler.Events.Publish(new CombatEvent.PerformAbilityEvent( this));
    }
}
