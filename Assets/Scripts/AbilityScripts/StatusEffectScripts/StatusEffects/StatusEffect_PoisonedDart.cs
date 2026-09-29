using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Status Effects/Poisoned Dart")]
public class StatusEffect_PoisonedDart : StatusEffect
{
    public int DamagePerTurn;
    public int InitiativeReduction;
    public override IStatusEffectBehaviour[] StatusEffectBehaviours => new IStatusEffectBehaviour[] { 
        new DamageOverTimeSEBehaviour(DamagePerTurn),
        new ModifyInitiativeBehaviour(InitiativeReduction)};

    public override float[] StrengthScoreModifiers => new[] { 1f, 0f };
}
