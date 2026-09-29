using System;
using UnityEngine;

public class RangeSingleOpponentComponent : TargetingComponent
{
    private int minimumRange;

    public RangeSingleOpponentComponent(int minimumRange)
    {
        this.minimumRange = minimumRange;
    }

    protected override Combatant[] GetPossibleTargets(Combatant user)
    {
        var tmp = CombatHandler.State.GetOpponentTeam(user);

        if (minimumRange > 0)
        {
            Array.Reverse(tmp);
            Array.Resize(ref tmp, minimumRange);
        }

        return tmp;
    }

    protected override Combatant[] GetFinalTargets(Combatant user, Combatant[] possibleTargets, Combatant clicked)
    {
        return new[] { clicked };
    }
}
