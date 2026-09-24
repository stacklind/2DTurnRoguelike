public class CombatUIEvent
{
    public class ShowCombatantTooltipEvent
    {
        public readonly Combatant Combatant;

        public ShowCombatantTooltipEvent(Combatant combatant)
        {
            Combatant = combatant;
        }
    }

    public class ShowAbilityTooltipEvent
    {
        public readonly Ability Ability;
        public readonly Combatant Combatant;
        
        public ShowAbilityTooltipEvent(Ability ability, Combatant combatant)
        {
            Ability = ability;
            Combatant = combatant;
        }
    }

    public class ClearTooltipEvent
    {
        public ClearTooltipEvent()
        {
        }
    }
}
