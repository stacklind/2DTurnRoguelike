using UnityEngine;

public class ModifyInitiativeBehaviour : IStatusEffectBehaviour
{
    private Combatant appliedTo;
    private int modificationAmount;
    public int StrengthScore => Mathf.Abs(modificationAmount);

    public ModifyInitiativeBehaviour(int amount)
    {
        modificationAmount = amount;
    }

    public void OnApplication(Combatant user, Combatant target)
    {
        appliedTo = target;
        appliedTo.Character.Initiative += modificationAmount;
    }

    public void OnRemoval()
    {
        appliedTo.Character.Initiative -= modificationAmount;
    }

    public void OnTick() { }
}
