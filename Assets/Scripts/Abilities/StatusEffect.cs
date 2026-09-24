using UnityEngine;

public abstract class StatusEffect : ScriptableObject
{
    private Combatant appliedTo;
    private int stacks;

    public string Name;
    public int InitialStacks;
    public int MaxStacks;
    public SEType Type;
    public Sprite Icon;

    public int Stacks 
    {
        get => stacks;
        set
        {
            stacks = value;
            if(stacks > MaxStacks)
            {
                stacks = MaxStacks;
            }
            if(stacks <= 0)
            {
                RemoveInternal(appliedTo);
            }
        }
    }
    public abstract int StrengthScore { get; }

    public void Apply(Combatant combatant)
    {
        appliedTo = combatant;
        ApplyInternal(appliedTo);
    }

    public bool Equals(StatusEffect other) => Name == other.Name;

    public override bool Equals(object obj) => Equals(obj as StatusEffect);

    public override int GetHashCode() => Name.GetHashCode() * 17;

    public virtual void Tick(int stacksToRemove)
    {
        stacks -= stacksToRemove;
    }

    protected abstract void ApplyInternal(Combatant combatant);
    protected abstract void RemoveInternal(Combatant combatant);
}

public enum SEType
{
    Duration,
    Trigger
}