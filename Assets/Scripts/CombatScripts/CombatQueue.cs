using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CombatQueue
{
    private List<Combatant> combatants;
    private int currentIndex;

    public Combatant Current => combatants[currentIndex];

    public CombatQueue(Combatant[] combatants)
    {
        this.combatants = new List<Combatant>(combatants);
        currentIndex = 0;
        SortCombatants(null);
        CombatHandler.Events.Subscribe<CombatEvent.InitiativeChangedEvent>(SortCombatants);
        IsItPlayersTurn();
    }

    public void EndTurn()
    {
        UpdateIndex();
        IsItPlayersTurn();
    }

    private void IsItPlayersTurn()
    {
        if (Current.IsPlayer)
        {
            CombatHandler.Events.Publish(new CombatEvent.BeginPlayerTurnEvent(Current));
        }
    }

    private void SortCombatants(CombatEvent.InitiativeChangedEvent evt)
    {
        combatants = combatants.OrderBy(x => x.Character.Initiative).ToList();
    }

    private void UpdateIndex()
    {
        currentIndex = (currentIndex + 1) % combatants.Count;
    }
}
