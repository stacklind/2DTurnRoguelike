using UnityEngine;

public class AoeAllOpponentsComponent : TargetingComponent
{
    protected override Combatant[] GetFinalTargets(Combatant user, Combatant[] possibleTargets, Combatant clicked)
    {
        return possibleTargets;
    }

    protected override Combatant[] GetPossibleTargets(Combatant user)
    {
        return CombatHandler.State.GetOpponentTeam(user);
    }
}
