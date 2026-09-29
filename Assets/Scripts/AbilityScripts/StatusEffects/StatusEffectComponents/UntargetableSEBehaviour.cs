using UnityEngine;

public class UntargetableSEBehaviour : IStatusEffectBehaviour
{
    private Combatant appliedTo;

    public int StrengthScore => 5;

    public void OnApplication(Combatant user, Combatant target)
    {
        appliedTo = target;
        target.IsTargetable = false;
    }

    public void OnRemoval()
    {
        appliedTo.IsTargetable = true;
    }

    public void OnTick() { }
}
