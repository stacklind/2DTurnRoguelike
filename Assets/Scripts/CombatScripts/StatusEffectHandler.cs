using System.Collections.Generic;
using UnityEngine;

public class StatusEffectHandler
{
    private Combatant _owner;
    private StatusEffectHandlerUI _UI;

    private HashSet<StatusEffectInstance> timedSEs;
    private HashSet<StatusEffectInstance> triggeredSEs;

    public int StacksReducedPerTurn { get; set; } = 1;

    public StatusEffectHandler(StatusEffectHandlerUI ui, Combatant owner)
    {
        _owner = owner;
        _UI = ui;
        timedSEs = new HashSet<StatusEffectInstance>();
        triggeredSEs = new HashSet<StatusEffectInstance>();
        CombatHandler.Events.Subscribe<CombatEvent.EndTurnEvent>(HandleEndTurnEvent);
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
        CombatHandler.Events.Unsubscribe<CombatEvent.EndTurnEvent>(HandleEndTurnEvent);

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

    private void HandleEndTurnEvent(CombatEvent.EndTurnEvent evt)
    {
        if(evt.CurrentCombatant == _owner)
        {
            Tick();
        }
    }

    private void Tick()
    {
        List<StatusEffectInstance> toRemove = new List<StatusEffectInstance>();
        foreach (TimedStatusEffectInstance sei in timedSEs)
        {
            sei.Tick(StacksReducedPerTurn);
            
            if(sei.Stacks > 0)
            {
                _UI.UpdateStatusEffect(sei);
            }
            else
            {
                toRemove.Add(sei);
            }
        }

        foreach(StatusEffectInstance sei in toRemove)
        {
            timedSEs.Remove(sei);
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
