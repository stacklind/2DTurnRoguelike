using UnityEngine;

public class TargetSelfComponent : TargetingComponent
{
    protected override Combatant[] GetPossibleTargets(Combatant user)
    {
        return new[] { user }; 
    }

    protected override Combatant[] GetFinalTargets(Combatant user, Combatant[] possibleTargets, Combatant clicked)
    {
        return possibleTargets;
    }
}
