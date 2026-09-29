using UnityEngine;

public abstract class StatusEffectInstance
{
    private int stacks;
    private int maxStacks;
    private bool isBuff;
    
    protected IStatusEffectBehaviour[] statusEffectBehaviours;
    protected float[] strengthScoreModifiers;

    public Combatant AppliedTo { get; }
    public Sprite Icon { get; }
    public string Name;
    public int Stacks
    {
        get => stacks;

        set
        {
            stacks = value;
            if(stacks > maxStacks)
            {
                stacks = maxStacks;
            }
            else if(stacks <= 0)
            {
                Remove();
            }
        }
    }
    public int StrengthScore
    {
        get
        {
            int score = 0;
            for (int i = 0; i < statusEffectBehaviours.Length; i++)
            {
                score += Mathf.FloorToInt(statusEffectBehaviours[i].StrengthScore * strengthScoreModifiers[i]);
            }
            return score;
        }
    }

    public StatusEffectInstance(StatusEffect statusEffect, Combatant user, Combatant target)
    {
        maxStacks = statusEffect.MaxStacks > 0 ? statusEffect.MaxStacks : int.MaxValue;
        isBuff = statusEffect.IsBuff;
        Name = statusEffect.Name;
        Stacks = statusEffect.InitialStacks;
        Icon = statusEffect.Icon;
        statusEffectBehaviours = statusEffect.StatusEffectBehaviours;
        strengthScoreModifiers = statusEffect.StrengthScoreModifiers;

        AppliedTo = target;

        foreach(IStatusEffectBehaviour seb in statusEffectBehaviours)
        {
            seb.OnApplication(user, target);
        }
    }

    protected virtual void Remove()
    {
        foreach(IStatusEffectBehaviour seb in statusEffectBehaviours)
        {
            seb.OnRemoval();
        }
        if(isBuff)
        {
            AppliedTo.RemoveBuff(this);
        }
        else
        {
            AppliedTo.RemoveDebuff(this);
        }
    }

    public bool Equals(StatusEffectInstance other) => Name == other.Name;
    public override bool Equals(object obj) => obj is StatusEffectInstance && Equals(obj as StatusEffectInstance);

    public override int GetHashCode() => Name.GetHashCode() * 17 * 31;
}