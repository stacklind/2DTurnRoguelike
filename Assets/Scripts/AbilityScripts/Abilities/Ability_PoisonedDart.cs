using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Abilities/Poisoned Dart")]
public class Ability_PoisonedDart : Ability
{
    public int MinRange;
    public float DamageModifier;
    public StatusEffect_PoisonedDart statusEffect;

    private void OnEnable()
    {
        TargetingComponent = new RangeSingleOpponentComponent(MinRange);
        EffectComponents = new IEffectComponent[] { new StatusEffectComponent(statusEffect), new DamageEffectComponent(DamageModifier) };
    }

    public override string GetTooltip(Combatant user)
    {
        return $"Shoot a poisoned dart at a target, dealing {Mathf.FloorToInt(DamageModifier * user.Character.Damage.MinDamage)} - " +
            $"{Mathf.FloorToInt(DamageModifier * user.Character.Damage.MaxDamage)}, and poisoning them for {statusEffect.InitialStacks} turns, " +
            $"reducing their initiative by {statusEffect.InitiativeReduction} and dealing {statusEffect.DamagePerTurn} damage per turn.";
    }
}