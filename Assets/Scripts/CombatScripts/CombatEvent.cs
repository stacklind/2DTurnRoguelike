public class CombatEvent
{
    private interface ICombatStepEvent<T>
    {
        public T Step { get; }
    }

    public class AbilityActivatedEvent
    {
        public readonly Ability Ability;
        public readonly Combatant User;
        public readonly Combatant[] Targets;

        public AbilityActivatedEvent(Ability ability, Combatant user, Combatant[] targets)
        {
            Ability = ability;
            User = user;
            Targets = targets;
        }
    }

    public class AbilityConfirmedEvent
    {
        public readonly TargetingPackage Package;

        public AbilityConfirmedEvent(TargetingPackage package)
        {
            Package = package;
        }
    }

    public class AquireTargetsEvent
    {
        public readonly TargetingPackage Package;

        public AquireTargetsEvent(TargetingPackage package)
        {
            Package = package;
        }
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
        public readonly bool Died;
        public readonly Combatant Source;
        public readonly Combatant Target;


        public DamageEvent(int amount, Combatant source, Combatant target, bool died)
        {
            Amount = amount;
            Source = source;
            Target = target;
            Died = died;
        }
    }

    public class DeathEvent
    {
        public readonly Combatant Combatant;
        public DeathEvent(Combatant combatant)
        {
            Combatant = combatant;
        }
    }

    public class EndTurnEvent : ICombatStepEvent<EndTurnStep>
    {
        public readonly Combatant CurrentCombatant;
        public EndTurnStep Step { get; }
        public EndTurnEvent(Combatant currentCombatant, EndTurnStep step)
        {
            CurrentCombatant = currentCombatant;
            Step = step;
        }
    }

    public class InitiativeChangedEvent
    {

    }

    public class PerformAbilityEvent : ICombatStepEvent<PerformAbilityStep>
    {
        public PerformAbilityStep Step { get; }

        public PerformAbilityEvent(PerformAbilityStep step)
        {
            Step = step;
        }
    }

    public class TargetsAquiredEvent
    {
        public readonly Combatant User;
        public readonly Combatant[] Targets;

        public TargetsAquiredEvent(Combatant user, Combatant[] targets)
        {
            User = user;
            Targets = targets;
        }
    }
}
