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
        CombatHandler.Events.Subscribe<CombatUIEvent.ShowMoveToolTipEvent>(BuildMoveToolTip);
        CombatHandler.Events.Subscribe<CombatUIEvent.ClearToolTipEvent>(ClearToolTip);
    }

    private void OnDisable()
    {
        CombatHandler.Events.Unsubscribe<CombatUIEvent.ShowMoveToolTipEvent>(BuildMoveToolTip);
        CombatHandler.Events.Unsubscribe<CombatUIEvent.ClearToolTipEvent>(ClearToolTip);
    }

    private void BuildMoveToolTip(CombatUIEvent.ShowMoveToolTipEvent evt)
    {
        headerText.text = evt.Move.Name;
        string body = "";
        if(evt.Move is IDealsDamage)
        {
            body += $"Dmg: {((IDealsDamage)evt.Move).DamageModifier}x\n";
        }
        if(evt.Move is ICanCrit)
        {
            body += $"Crit chance: {((ICanCrit)evt.Move).CritChanceModifier}x\n";
        }
        bodyText.text = body.Substring(0, body.Length - 1);
    }

    private void ClearToolTip(CombatUIEvent.ClearToolTipEvent evt)
    {
        headerText.text = "";
        bodyText.text = "";
    }
}
