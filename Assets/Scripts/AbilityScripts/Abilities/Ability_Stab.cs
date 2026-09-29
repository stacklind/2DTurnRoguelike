using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Abilities/Stab")]
public class Ability_Stab : Ability
{
    public int baseRange;
    public float DamageModifier;
    public float CritModifier;

    private void OnEnable()
    {
        TargetingComponent = new MeleeSingleOpponentComponent(baseRange);
        EffectComponents = new[] { new DamageEffectComponent(DamageModifier, CritModifier) }; 
    }

    public override string GetTooltip(Combatant user)
    {
        return $"Deal {Mathf.FloorToInt(DamageModifier * user.Character.Damage.MinDamage)} - " +
            $"{Mathf.FloorToInt(DamageModifier * user.Character.Damage.MaxDamage)} damage to the closest enemy.";
    }
}
