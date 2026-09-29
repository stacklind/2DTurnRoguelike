using System;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatHandler : MonoBehaviour
{
    private static EventBroker _events;
    public static EventBroker Events 
    { 
        get
        {
            if(_events == null)
            {
                _events = new EventBroker();
            }

            return _events;
        }
    }

    public static CombatState State { get; private set; }

    [SerializeField]
    private Combatant[] playerCombatants;
    [SerializeField]
    private Combatant[] monsterCombatants;
    private CombatQueue combatQueue;

    private CombatStep currentCombatStep;

    private void Awake()
    {
        InitializeEvents();
    }

    private void OnDestroy()
    {
        _events = null;
    }

    private void Start()
    {
        CombatLoadData.Refresh();
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

    private Combatant[] BuildTeam(Character[] team, bool isPlayer)
    {
        Combatant[] combatantTeam = new Combatant[team.Length];

        for (int i = 0; i < team.Length; i++)
        {
            Combatant c = isPlayer ? playerCombatants[i] : monsterCombatants[i];
            c.Initialize(team[i], isPlayer);
            combatantTeam[i] = c;
        }

        return combatantTeam;
    }

    private void DoMonsterTurn(Combatant monster)
    {
        monster.Character.Abilities[0].Select(monster);
    }

    private void HandleNewTurnEvent(CombatEvent.BeginTurnEvent evt)
    {
        if (!evt.Combatant.IsPlayer)
        {
            DoMonsterTurn(evt.Combatant);
        }
    }

    private void HideCombatants()
    {
        foreach (Combatant c in playerCombatants)
        {
            c.UI.gameObject.SetActive(false);
            c.gameObject.SetActive(false);
        }
        foreach (Combatant c in monsterCombatants)
        {
            c.UI.gameObject.SetActive(false);
            c.gameObject.SetActive(false);
        }
    }

    private void InitializeEvents()
    {
        Events.Subscribe<CombatEvent.BeginCombatEvent>(InitializeCombatants);
        Events.Subscribe<CombatEvent.BeginTurnEvent>(HandleNewTurnEvent);
    }

    private void InitializeCombatants(CombatEvent.BeginCombatEvent evt)
    {
        HideCombatants();

        Combatant[] playerTeam = BuildTeam(CombatLoadData.Team1.ToArray(), true);
        Combatant[] monsterTeam = BuildTeam(CombatLoadData.Team2.ToArray(), false);

        State = new CombatState(playerTeam, monsterTeam);
        combatQueue = new CombatQueue(playerTeam.Concat(monsterTeam).ToArray());

        evt.Step.StartingCombatant = combatQueue.Current;
        evt.Step.CompleteTask();
    }

    
}

[Flags]
public enum Positions
{
    None = 0,
    First = 1,
    Second = 2,
    Third = 4,
    Forth = 8,
    All = ~None
}