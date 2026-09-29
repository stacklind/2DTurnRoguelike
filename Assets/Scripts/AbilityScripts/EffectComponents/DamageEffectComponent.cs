using UnityEngine;

public class DamageEffectComponent : IEffectComponent
{
    private float damageModifier;
    private float critChanceModifier;
    private float critMultiplierModifier;

    public DamageEffectComponent(float damageModifier = 1f, float critChanceModifier = 1f, float critMultiplierModifier = 0f)
    {
        this.damageModifier = damageModifier;
        this.critChanceModifier = critChanceModifier;
        this.critMultiplierModifier = critMultiplierModifier;
    }

    public void ApplyEffect(Combatant user, Combatant target)
    {
        float finalModifier = damageModifier * (user.Character.Crit.Roll(critChanceModifier) + critMultiplierModifier);

        target.TakeDamage(user.Character.Damage.CalculateDamage(finalModifier), user);
    }
}
