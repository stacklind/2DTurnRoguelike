using System.Collections.Generic;

public class StatusEffectHandler
{
    private StatusEffectHandlerUI _UI;

    private HashSet<StatusEffectInstance> timedSEs;
    private HashSet<StatusEffectInstance> triggeredSEs;

    public int StacksReducedPerTurn { get; set; } = 1;

    public StatusEffectHandler(StatusEffectHandlerUI ui)
    {
        _UI = ui;
        timedSEs = new HashSet<StatusEffectInstance>();
        triggeredSEs = new HashSet<StatusEffectInstance>();
        CombatHandler.Events.Subscribe<CombatEvent.EndTurnEvent>(e => Tick());
    }

    public void Add(StatusEffectInstance se)
    {
        HashSet<StatusEffectInstance> set = GetSetFromType(se);
        
        if (set.TryGetValue(se, out StatusEffectInstance current))
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

        foreach(StatusEffectInstance se in timedSEs)
        {
            Remove(se);
        }
        foreach(StatusEffectInstance se in triggeredSEs)
        {
            Remove(se);
        }
    }

    public void Remove(StatusEffectInstance se)
    {
        HashSet<StatusEffectInstance> set = GetSetFromType(se);

        set.Remove(se);
        _UI.RemoveStatusEffect(se);
    }

    private HashSet<StatusEffectInstance> GetSetFromType(StatusEffectInstance se)
    {
        if (se is TimedStatusEffectInstance)
        {
            return timedSEs;
        }
        else
        {
            return triggeredSEs;
        }
    }

    private void Tick()
    {
        foreach (TimedStatusEffectInstance se in timedSEs)
        {
            se.Tick(StacksReducedPerTurn);
            
            if(se.Stacks > 0)
            {
                _UI.UpdateStatusEffect(se);
            }
            else
            {
                timedSEs.Remove(se);
                _UI.RemoveStatusEffect(se);
            }
        }
    }

    private void ReapplyStatusEffect(StatusEffectInstance newSE, StatusEffectInstance currentSE, HashSet<StatusEffectInstance> set)
    {
        int stacks = newSE.Stacks + currentSE.Stacks;
        if (newSE.StrengthScore > currentSE.StrengthScore)
        {
            currentSE.Stacks = 0;
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
