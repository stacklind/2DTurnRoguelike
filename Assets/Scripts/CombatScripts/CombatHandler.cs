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

    private CombatStep currentCombatStep;

    private int turn = 0;

    public CombatHandler()
    {
        InitializeEvents();

    }

    private void Awake()
    {
        CombatLoadData.Refresh();
        CombatLoadData.Team1.Add(Rogue.RandomlyGenerate());
        CombatLoadData.Team1.Add(Rogue.RandomlyGenerate());
        CombatLoadData.Team2.Add(new Bandit());
        CombatLoadData.Team2.Add(new Bandit());
    }

    private void Start()
    {
        currentCombatStep = new BeginCombatStep();
        currentCombatStep.Begin();
    }

    private void Update()
    {
        if(currentCombatStep.IsCompleted)
        {
            currentCombatStep = currentCombatStep.NextStep;
            currentCombatStep.Begin();
        }
    }

    private void HandleNewTurnEvent(CombatEvent.BeginTurnEvent evt)
    {
        Debug.Log($"Turn: {turn++}");

        if(!evt.Combatant.IsPlayer)
        {
            DoMonsterTurn(evt.Combatant);
        }
    }

    private void DoMonsterTurn(Combatant combatant)
    {
        Events.Publish(new CombatEvent.MoveChosenEvent(combatant.Character.MoveSet[0]));
    }

    private void InitializeEvents()
    {
        Events = new EventBroker();
        Events.Subscribe<CombatEvent.BeginCombatEvent>(InitializeCombatants);
        Events.Subscribe<CombatEvent.BeginTurnEvent>(HandleNewTurnEvent);
    }

    private void InitializeCombatants(CombatEvent.BeginCombatEvent evt)
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

        evt.Step.StartingCombatant = combatQueue.Current;
        evt.Step.CompleteTask();
    }
}