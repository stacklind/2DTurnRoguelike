using UnityEngine;

public class PerformMoveStep : CombatStep
{
    public override CombatStep NextStep => new UpdateBattlefieldStep(move, user);

    private Combatant user;
    private Move move;

    public PerformMoveStep(Move move, Combatant user)
    {
        this.move = move;
        this.user = user;

        // Checklist
        //  - Play animation
        AddTask();
        //  - Play sound
        AddTask();
        //
        // Total: 2
    }

    public override void Begin()
    {
        CombatHandler.Events.Publish(new CombatEvent.PerformMoveEvent(user, move, this));
    }
}
