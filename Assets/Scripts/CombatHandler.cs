using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombatHandler : MonoBehaviour
{
    private int MAX_TEAM_SIZE = 4;

    // Data
    private int current;

    // Combatants
    [SerializeField]
    private GameObject[] combatantObjects;
    private List<Combatant> combatOrder;
    private List<Combatant> team1;
    private List<Combatant> team2;
    private Combatant currentCombatant;

    // UI
    [SerializeField]
    private TextMeshProUGUI healthInfo;
    [SerializeField]
    private TextMeshProUGUI energyInfo;
    [SerializeField]
    private TextMeshProUGUI statusInfo;
    [SerializeField]
    private MoveButton[] moveButtons;

    private void Awake()
    {
        InitializeData();
        InitializeCombatants();
        InitializeUI();
    }

    private void Update()
    {
        if (!currentCombatant.IsPlayer)
        {
            EndTurn();
            return;
        }
    }

    public void EndTurn()
    {
        current = (current + 1) % combatOrder.Count;
        currentCombatant = combatOrder[current];

        UpdateUI();
    }

    public Combatant[] GetPlayerTeam()
    {
        return team1.ToArray();
    }

    public Combatant[] GetMonsterTeam()
    {
        return team2.ToArray();
    }

    public void UseMove(int index)
    {
        Move move = currentCombatant.Character.MoveSet[index];

        if(currentCombatant.Character.CurrentEnergy < move.EnergyCost)
        {
            // TODO
            Debug.Log("Not enough energy");
            return;
        }

        currentCombatant.Character.CurrentEnergy -= move.EnergyCost;
        move.Use(this, currentCombatant.Character);
    }

    private void InitializeData()
    {
        current = 0;
    }

    private void InitializeCombatants()
    {
        combatOrder = new List<Combatant>();
        team1 = new List<Combatant>();
        team2 = new List<Combatant>();

        for (int i = 0; i < CombatData.Team1.Count; i++)
        {
            Combatant c = new Combatant(CombatData.Team1[i], true, combatantObjects[i].GetComponent<CombatantMono>());
            combatOrder.Add(c);
            team1.Add(c);
            combatantObjects[i].SetActive(true);
        }

        for(int i = 0; i < CombatData.Team2.Count; i++)
        {
            Combatant c = new Combatant(CombatData.Team2[i], false, combatantObjects[i + MAX_TEAM_SIZE].GetComponent<CombatantMono>());
            combatOrder.Add(c);
            team2.Add(c);
            combatantObjects[i + MAX_TEAM_SIZE].SetActive(true);
        }

        combatOrder = combatOrder.OrderBy(x => x.Character.Initiative).ToList();
        currentCombatant = combatOrder[current];
    }

    private void InitializeUI()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        UpdateInfo();
        UpdateMoveButtons();
    }

    private void UpdateInfo()
    {
        healthInfo.text = $"{currentCombatant.Character.CurrentHealth}/{currentCombatant.Character.MaxHealth}";
        energyInfo.text = $"{currentCombatant.Character.CurrentEnergy}/{currentCombatant.Character.MaxEnergy}";
        statusInfo.text = "<<PLACEHOLDER>>";
    }

    private void UpdateMoveButtons()
    {
        foreach(MoveButton b in moveButtons)
        {
            b.gameObject.SetActive(false);
        }

        for (int i = 0; i < currentCombatant.Character.MoveSet.Count; i++)
        {
            moveButtons[i].MoveName = currentCombatant.Character.MoveSet[i].Name;
            moveButtons[i].MoveCost = currentCombatant.Character.MoveSet[i].EnergyCost.ToString();
            moveButtons[i].gameObject.SetActive(true);
        }
    }
}