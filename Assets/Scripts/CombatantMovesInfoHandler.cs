using UnityEngine;

public class CombatantMovesInfoHandler : MonoBehaviour
{
    [SerializeField]
    private MoveButton[] moveButtons;
    private Combatant currentCombatant;

    private void OnEnable()
    {
        CombatHandler.Events.Subscribe<CombatEvent.BeginPlayerTurnEvent>(UpdateButtons);
        InitializeButtons();
    }

    private void OnDisable()
    {
        CombatHandler.Events.Unsubscribe<CombatEvent.BeginPlayerTurnEvent>(UpdateButtons);
    }

    private void UpdateButtons(CombatEvent.BeginPlayerTurnEvent evt)
    {
        currentCombatant = evt.Combatant;

        foreach(MoveButton b in moveButtons)
        {
            b.Decativate();
        }
        for(int i = 0; i < evt.Combatant.Character.MoveSet.Count; i++)
        {
            moveButtons[i].Activate(evt.Combatant.Character.MoveSet[i]);
        }
    }

    private void OnClick(int buttonIndex)
    {

        currentCombatant.UseMove(buttonIndex);
    }

    private void InitializeButtons()
    {
        moveButtons[0].Button.onClick.AddListener(() => OnClick(0));
        moveButtons[1].Button.onClick.AddListener(() => OnClick(1));
        moveButtons[2].Button.onClick.AddListener(() => OnClick(2));
        moveButtons[3].Button.onClick.AddListener(() => OnClick(3));
    }
}
