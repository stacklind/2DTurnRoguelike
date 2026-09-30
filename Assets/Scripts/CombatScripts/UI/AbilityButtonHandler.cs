using UnityEngine;

public class AbilityButtonHandler : MonoBehaviour
{
    private AbilityButton[] abilityButtons;
    private Combatant currentCombatant;

    private void Awake()
    {
        abilityButtons = GetComponentsInChildren<AbilityButton>();
    }

    private void Start()
    {
        InitializeButtons();
    }

    private void OnEnable()
    {
        CombatHandler.Events.Subscribe<CombatEvent.BeginTurnEvent>(HandleBTE);
    }

    private void OnDisable()
    {
        CombatHandler.Events.Unsubscribe<CombatEvent.BeginTurnEvent>(HandleBTE);
    }

    private void HandleBTE(CombatEvent.BeginTurnEvent evt)
    {
        if (evt.Combatant.IsPlayer)
        {
            UpdateButtons(evt.Combatant);
        }
    }

    private void UpdateButtons(Combatant combatant)
    {
        currentCombatant = combatant;

        foreach(AbilityButton b in abilityButtons)
        {
            b.Decativate();
        }
        for(int i = 0; i < combatant.Character.Abilities.Count; i++)
        {
            abilityButtons[i].Activate(combatant.Character.Abilities[i], combatant);
        }
    }

    private void OnClick(int buttonIndex)
    {
        currentCombatant.Character.Abilities[buttonIndex].Select(currentCombatant);
    }

    private void InitializeButtons()
    {
        foreach (AbilityButton b in abilityButtons)
        {
            b.Decativate();
        }
        abilityButtons[0].Button.onClick.AddListener(() => OnClick(0));
        abilityButtons[1].Button.onClick.AddListener(() => OnClick(1));
        abilityButtons[2].Button.onClick.AddListener(() => OnClick(2));
        abilityButtons[3].Button.onClick.AddListener(() => OnClick(3));
    }
}
