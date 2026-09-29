using UnityEngine;

public abstract class StatusEffect : ScriptableObject
{
    public string Name;
    public bool IsBuff;
    public int InitialStacks;
    public int MaxStacks;
    public Sprite Icon;
    public abstract IStatusEffectBehaviour[] StatusEffectBehaviours { get; }
    public abstract float[] StrengthScoreModifiers { get; }
}