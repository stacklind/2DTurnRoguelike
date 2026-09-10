using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CombatHandler : MonoBehaviour
{
    // General stuff
    [SerializeField]
    private int maxTeamSize = 2;

    // Data
    private int activeTeam;
    private int current;
    private Combatant currentCombatant;
    private List<Combatant> combatOrder;

    // Combatants
    [SerializeField]
    private GameObject[] combatantObjects;

    // UI
    [SerializeField]
    private TextMeshProUGUI healthInfo;
    [SerializeField]
    private TextMeshProUGUI energyInfo;
    [SerializeField]
    private TextMeshProUGUI statusInfo;

    private void Awake()
    {
        InitializeData();
        InitializeCombatants();
        InitializeUI();
    }

    private void Update()
    {
        if (!currentCombatant.IsPlayer) EndTurn();
    }

    public void UseMove(int index)
    {
        currentCombatant.UseMove(index);
    }

    public void EndTurn()
    {
        current = (current + 1) % combatOrder.Count;
        currentCombatant = combatOrder[current];

        UpdateUI();
    }

    private void InitializeData()
    {
        current = 0;
        activeTeam = 0;
        combatOrder = new List<Combatant>();

        combatOrder.AddRange(CombatData.Team1);
        combatOrder.AddRange(CombatData.Team2);
        combatOrder = combatOrder.OrderBy(x => x.Character.Initiative).ToList();

        currentCombatant = combatOrder[current];
    }

    private void InitializeCombatants()
    {
        for(int i = 0; i < CombatData.Team1.Count; i++)
        {
            combatantObjects[i].SetActive(true);
        }

        for(int i = 0; i < CombatData.Team2.Count; i++)
        {
            combatantObjects[i+maxTeamSize].SetActive(true);
        }
    }

    private void InitializeUI()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        healthInfo.text = $"{currentCombatant.Character.CurrentHealth}/{currentCombatant.Character.MaxHealth}";
        energyInfo.text = $"{currentCombatant.Character.CurrentEnergy}/{currentCombatant.Character.MaxEnergy}";
        statusInfo.text = "<<PLACEHOLDER>>";
    }
}