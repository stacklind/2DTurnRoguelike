using UnityEngine;

public class MoveButtonHandler : MonoBehaviour
{
    [SerializeField]
    private MoveButton[] moveButtons;
    private Combatant currentCombatant;

    private void OnEnable()
    {
        CombatHandler.Events.Subscribe<CombatEvent.BeginTurnEvent>(HandleEvent);
        InitializeButtons();
    }

    private void OnDisable()
    {
        CombatHandler.Events.Unsubscribe<CombatEvent.BeginTurnEvent>(HandleEvent);
    }

    private void HandleEvent(CombatEvent.BeginTurnEvent evt)
    {
        if (evt.Combatant.IsPlayer)
        {
            UpdateButtons(evt.Combatant);
        }
        evt.Step.CompleteTask();
    }

    private void UpdateButtons(Combatant combatant)
    {
        currentCombatant = combatant;

        foreach(MoveButton b in moveButtons)
        {
            b.Decativate();
        }
        for(int i = 0; i < combatant.Character.MoveSet.Count; i++)
        {
            moveButtons[i].Activate(combatant.Character.MoveSet[i]);
        }
    }

    private void OnClick(int buttonIndex)
    {
        CombatHandler.Events.Publish(new CombatEvent.MoveChosenEvent(currentCombatant.Character.MoveSet[buttonIndex]));
    }

    private void InitializeButtons()
    {
        foreach (MoveButton b in moveButtons)
        {
            b.Decativate();
        }
        moveButtons[0].Button.onClick.AddListener(() => OnClick(0));
        moveButtons[1].Button.onClick.AddListener(() => OnClick(1));
        moveButtons[2].Button.onClick.AddListener(() => OnClick(2));
        moveButtons[3].Button.onClick.AddListener(() => OnClick(3));
    }
}
