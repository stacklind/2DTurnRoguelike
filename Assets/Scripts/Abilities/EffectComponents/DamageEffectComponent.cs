using UnityEngine;

public class DamageEffectComponent : IEffectComponent
{
    public float DamageModifier;
    public float CritChanceModifier;
    public float CritMultiplierModifier;

    public DamageEffectComponent(float damageModifier = 1f, float critChanceModifier = 1f, float critMultiplierModifier = 0f)
    {
        DamageModifier = damageModifier;
        CritChanceModifier = critChanceModifier;
        CritMultiplierModifier = critMultiplierModifier;
    }

    public void ApplyEffect(Combatant user, Combatant target)
    {
        Debug.Log($"DamageEffectComponent > ApplyEffect (User: {user.gameObject.name}, Target: {target.gameObject.name})");

        float finalModifier = DamageModifier * (user.Character.Crit.Roll(CritChanceModifier) + CritMultiplierModifier);

        target.TakeDamage(user.Character.Damage.CalculateDamage(finalModifier));
    }
}
