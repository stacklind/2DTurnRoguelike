using UnityEngine;

public class UpdateBattlefieldStep : CombatStep
{
    public override CombatStep NextStep => new EndTurnStep();

    private Move move;
    private Combatant combatant;

    public UpdateBattlefieldStep(Move move, Combatant user)
    {
        this.move = move;
        this.combatant = user;

        
        // Checklist size will depend on the move, calculated in Begin()
    }

    public override void Begin()
    {
        if (move is IDealsDamage)
        {
            AddTask();
            CombatHandler.Events.Subscribe<CombatEvent.DamageEvent>(OnDamageHandled);
        }

        combatant.UseMove(move);
    }

    private void OnDamageHandled(CombatEvent.DamageEvent evt)
    {
        CombatHandler.Events.Unsubscribe<CombatEvent.DamageEvent>(OnDamageHandled);
        Debug.Log($"{evt.Target.Character.Name} took {evt.Amount} damage. They have {evt.Target.Character.Health.CurrentHealth} hp remaining.");

        if(evt.Died)
        {
            AddTask();
            CombatHandler.Events.Publish(new CombatEvent.DeathEvent(evt.Target, this));
        }

        CompleteTask();
    }
}
