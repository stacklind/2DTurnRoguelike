using NUnit.Framework;
using System.Linq;
using UnityEngine;

public class CombatHandler : MonoBehaviour
{
    public static EventBroker Events { get; private set; }

    public static CombatState State { get; private set; }

    [SerializeField]
    private Combatant[] playerCombatants;
    [SerializeField]
    private Combatant[] monsterCombatants;
    private CombatQueue combatQueue;

    private void Awake()
    {
        InitializeEvents();
        InitializeCombatants();
    }

    private void Update()
    {
        if (!combatQueue.Current.IsPlayer)
        {
            EndTurn();
            return;
        }
    }

    public void EndTurn()
    {
        combatQueue.EndTurn();
    }

    private void InitializeEvents()
    {
        Events = new EventBroker();
        Events.Subscribe<CombatEvent.EndTurnEvent>(e => EndTurn());
    }

    private void InitializeCombatants()
    {
        Combatant[] playerTeam = new Combatant[CombatData.Team1.Count];
        Combatant[] monsterTeam = new Combatant[CombatData.Team2.Count];

        for (int i = 0; i < CombatData.Team1.Count; i++)
        {
            Combatant c = playerCombatants[i];
            c.Initialize(CombatData.Team1[i], true);
            c.gameObject.SetActive(true);
            playerTeam[i] = c;
        }

        for(int i = 0; i < CombatData.Team2.Count; i++)
        {
            Combatant c = monsterCombatants[i];
            c.Initialize(CombatData.Team2[i], false);
            c.gameObject.SetActive(true);
            monsterTeam[i] = c;
        }

        State = new CombatState(playerTeam, monsterTeam);
        combatQueue = new CombatQueue(playerTeam.Concat(monsterTeam).ToArray());
    }
}