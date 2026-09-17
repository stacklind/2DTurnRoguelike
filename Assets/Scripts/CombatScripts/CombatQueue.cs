using System.Collections.Generic;
using System.Linq;
using UnityEditor.PackageManager;
using UnityEngine;

public class CombatQueue
{
    private List<Combatant> combatants;
    private int currentIndex;

    public Combatant Current => combatants[currentIndex];

    public CombatQueue(Combatant[] combatants)
    {
        this.combatants = new List<Combatant>(combatants);
        currentIndex = 0;
        SortCombatants();
        CombatHandler.Events.Subscribe<CombatEvent.DeathEvent>(RemoveCombatant);
        CombatHandler.Events.Subscribe<CombatEvent.InitiativeChangedEvent>(e => SortCombatants());
        CombatHandler.Events.Subscribe<CombatEvent.EndTurnEvent>(EndTurn);
    }

    public void EndTurn(CombatEvent.EndTurnEvent evt)
    {
        UpdateIndex();

        evt.Step.nextCombatant = combatants[currentIndex];
        evt.Step.CompleteTask();
    }

    private void RemoveCombatant(CombatEvent.DeathEvent evt)
    {
        int index = combatants.IndexOf(evt.Combatant);
        combatants.RemoveAt(index);

        if(index < currentIndex)
        {
            currentIndex--;
        }

        evt.Step.CompleteTask();
        Debug.Log($"{evt.Combatant.Character.Name} was removed from the combat queue. Remaining combatants: {combatants.Count}, Current index: {currentIndex}");
    }

    private void SortCombatants()
    {
        combatants = combatants.OrderBy(x => x.Character.Initiative).ToList();
    }

    private void UpdateIndex()
    {
        currentIndex = (currentIndex + 1) % combatants.Count;
    }
}
