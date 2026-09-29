using System.Xml.Linq;
using UnityEngine;

public class DamageOverTimeSEBehaviour : IStatusEffectBehaviour
{
    private Combatant appliedTo;
    private Combatant owner;
    private int damagePerTick;

    public int StrengthScore => damagePerTick;

    public DamageOverTimeSEBehaviour(int damagePerTick)
    {
        this.damagePerTick = damagePerTick;
    }

    public void OnApplication(Combatant user, Combatant target)
    {
        // TODO: Modify damagePerTick based on user?
        owner = user;
        appliedTo = target;
    }

    public void OnTick()
    {
        appliedTo.TakeDamage(damagePerTick, owner);
    }

    public void OnRemoval() { }

    ~DamageOverTimeSEBehaviour() => Debug.Log($"Cleaning up dot on {appliedTo}"); // For testing purposes
}
