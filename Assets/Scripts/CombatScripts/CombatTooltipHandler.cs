using TMPro;
using UnityEngine;

public class CombatTooltipHandler : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI headerText;
    [SerializeField]
    private TextMeshProUGUI bodyText;

    private void OnEnable()
    {
        ClearToolTip(null);
        CombatHandler.Events.Subscribe<CombatUIEvent.ShowAbilityTooltipEvent>(BuildMoveToolTip);
        CombatHandler.Events.Subscribe<CombatUIEvent.ClearTooltipEvent>(ClearToolTip);
    }

    private void OnDisable()
    {
        CombatHandler.Events.Unsubscribe<CombatUIEvent.ShowAbilityTooltipEvent>(BuildMoveToolTip);
        CombatHandler.Events.Unsubscribe<CombatUIEvent.ClearTooltipEvent>(ClearToolTip);
    }

    private void BuildMoveToolTip(CombatUIEvent.ShowAbilityTooltipEvent evt)
    {
        bodyText.text = evt.Ability.GetTooltip(evt.Combatant);
    }

    private void ClearToolTip(CombatUIEvent.ClearTooltipEvent evt)
    {
        headerText.text = "";
        bodyText.text = "";
    }
}
