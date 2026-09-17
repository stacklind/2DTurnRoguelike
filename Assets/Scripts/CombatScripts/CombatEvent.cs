using System;

public class CombatEvent
{
    private interface ICombatStepEvent<T>
    {
        public T Step { get; }
    }
    public class BeginCombatEvent : ICombatStepEvent<BeginCombatStep>
    {
        public BeginCombatStep Step { get; }

        public BeginCombatEvent(BeginCombatStep step)
        {
            Step = step;
        }
    }

    public class BeginTurnEvent : ICombatStepEvent<BeginTurnStep>
    {
        public readonly Combatant Combatant;
        public BeginTurnStep Step { get; }

        public BeginTurnEvent(Combatant combatant, BeginTurnStep step)
        {
            Combatant = combatant;
            Step = step;
        }
    }

    public class DamageEvent
    {
        public readonly int Amount;
        public readonly Combatant Target;
        public readonly bool Died;

        public DamageEvent(int amount, Combatant target, bool died)
        {
            Amount = amount;
            Target = target;
            Died = died;
        }
    }

    public class DeathEvent
    {
        public readonly Combatant Combatant;
        public readonly UpdateBattlefieldStep Step;

        public DeathEvent(Combatant combatant, UpdateBattlefieldStep step)
        {
            Combatant = combatant;
            Step = step;
        }
    }

    public class EndTurnEvent : ICombatStepEvent<EndTurnStep>
    {
        public EndTurnStep Step { get; }
        public EndTurnEvent(EndTurnStep step)
        {
            Step = step;
        }
    }

    public class MoveChosenEvent
    {
        public readonly Move Move;

        public MoveChosenEvent(Move move)
        {
            Move = move;
        }
    }

    public class InitiativeChangedEvent
    {

    }

    public class PerformMoveEvent : ICombatStepEvent<PerformMoveStep>
    {
        public readonly Combatant User;
        public readonly Move Move;
        public PerformMoveStep Step { get; }

        public PerformMoveEvent(Combatant user, Move move, PerformMoveStep step)
        {
            User = user;
            Move = move;
            Step = step;
        }
    }
}
