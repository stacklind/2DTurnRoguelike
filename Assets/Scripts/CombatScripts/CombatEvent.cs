public class CombatEvent
{
    public class BeginPlayerTurnEvent
    {
        public readonly Combatant Combatant;

        public BeginPlayerTurnEvent(Combatant combatant)
        {
            Combatant = combatant;
        }
    }

    public class DamageEvent
    {
        public readonly int Amount;
        public readonly Combatant Target;

        public DamageEvent(int amount, Combatant target)
        {
            Amount = amount;
            Target = target;
        }
    }

    public class EndTurnEvent
    {
        public readonly Combatant Combatant;

        public EndTurnEvent(Combatant combatant)
        {
            Combatant = combatant;
        }
    }

    public class InitiativeChangedEvent
    {

    }
}
