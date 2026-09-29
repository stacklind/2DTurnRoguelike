using System;
using UnityEngine;

public class MeleeSingleOpponentComponent : TargetingComponent
{
    private int baseRange;

    public MeleeSingleOpponentComponent(int baseRange)
    {
        this.baseRange = baseRange;
    }

    protected override Combatant[] GetPossibleTargets(Combatant user)
    {
        var tmp = CombatHandler.State.GetOpponentTeam(user);

        if (tmp.Length > baseRange)
        {
            Array.Resize(ref tmp, baseRange);
        }

        return tmp;
    }

    protected override Combatant[] GetFinalTargets(Combatant user, Combatant[] possibleTargets, Combatant clicked)
    {
        return new[] { clicked };
    }
}
