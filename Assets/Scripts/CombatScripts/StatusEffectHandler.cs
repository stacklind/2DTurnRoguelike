using System.Collections.Generic;

public class StatusEffectHandler
{
    private StatusEffectHandlerUI _UI;

    private HashSet<StatusEffect> hasDuration;
    private HashSet<StatusEffect> hasUses;

    public int StacksReducedPerTurn { get; set; } = 1;

    public StatusEffectHandler(StatusEffectHandlerUI ui)
    {
        _UI = ui;
        hasDuration = new HashSet<StatusEffect>();
        hasUses = new HashSet<StatusEffect>();
        CombatHandler.Events.Subscribe<CombatEvent.EndTurnEvent>(e => Tick());
    }

    public void Add(StatusEffect se)
    {
        HashSet<StatusEffect> set = GetSetFromSEType(se.Type);
        
        if (set.TryGetValue(se, out StatusEffect current))
        {
            ReapplyStatusEffect(se, current, set);
        }
        else
        {
            set.Add(se);
            _UI.ApplyStatusEffect(se);
        }
    }

    public void Clear()
    {
        CombatHandler.Events.Unsubscribe<CombatEvent.EndTurnEvent>(e => Tick());

        foreach(StatusEffect se in hasDuration)
        {
            Remove(se);
        }
        foreach(StatusEffect se in hasUses)
        {
            Remove(se);
        }
    }

    public void Remove(StatusEffect se)
    {
        HashSet<StatusEffect> set = GetSetFromSEType(se.Type);

        se.Stacks = 0;
        set.Remove(se);
        _UI.RemoveStatusEffect(se);
    }

    private HashSet<StatusEffect> GetSetFromSEType(SEType type)
    {
        if (type == SEType.Duration)
        {
            return hasDuration;
        }
        else
        {
            return hasUses;
        }
    }

    private void Tick()
    {
        foreach (StatusEffect se in hasDuration)
        {
            se.Tick(StacksReducedPerTurn);
            
            if(se.Stacks > 0)
            {
                _UI.UpdateStatusEffect(se);
            }
            else
            {
                hasDuration.Remove(se);
                _UI.RemoveStatusEffect(se);
            }
        }
    }

    private void ReapplyStatusEffect(StatusEffect newSE, StatusEffect currentSE, HashSet<StatusEffect> set)
    {
        int stacks = newSE.Stacks + currentSE.Stacks;
        if (newSE.StrengthScore > currentSE.StrengthScore)
        {
            set.Remove(currentSE);
            set.Add(newSE);
        }
        else
        {
            newSE = currentSE;
        }
        newSE.Stacks = stacks;
        _UI.UpdateStatusEffect(newSE);
    }
}
