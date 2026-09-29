using UnityEngine;

public interface IStatusEffectBehaviour
{
    public int StrengthScore { get; }
    public void OnApplication(Combatant user, Combatant target);
    public void OnTick();
    public void OnRemoval();
}
