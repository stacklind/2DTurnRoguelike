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

    public CombatHandler()
    {
        InitializeEvents();
    }

    private void Awake()
    {
        InitializeCombatants();
    }

    private void Update()
    {
        if (!combatQueue.Current.IsPlayer)
        {
            combatQueue.Current.UseMove(0);
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
        Combatant[] playerTeam = new Combatant[CombatLoadData.Team1.Count];
        Combatant[] monsterTeam = new Combatant[CombatLoadData.Team2.Count];

        for (int i = 0; i < CombatLoadData.Team1.Count; i++)
        {
            Combatant c = playerCombatants[i];
            c.Initialize(CombatLoadData.Team1[i], true);
            c.gameObject.SetActive(true);
            playerTeam[i] = c;
        }

        for(int i = 0; i < CombatLoadData.Team2.Count; i++)
        {
            Combatant c = monsterCombatants[i];
            c.Initialize(CombatLoadData.Team2[i], false);
            c.gameObject.SetActive(true);
            monsterTeam[i] = c;
        }

        State = new CombatState(playerTeam, monsterTeam);
        combatQueue = new CombatQueue(playerTeam.Concat(monsterTeam).ToArray());
    }
}