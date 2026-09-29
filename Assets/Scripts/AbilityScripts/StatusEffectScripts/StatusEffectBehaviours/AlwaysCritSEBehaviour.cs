using UnityEngine;

public class AlwaysCritSEBehaviour : IStatusEffectBehaviour
{
    private Combatant appliedTo;
    public int StrengthScore => 10;

    public void OnApplication(Combatant user, Combatant target)
    {
        appliedTo = target;
        appliedTo.Character.Crit.AlwaysCrit = true;
    }

    public void OnRemoval()
    {
        appliedTo.Character.Crit.AlwaysCrit = false;
    }

    public void OnTick() { }
}
