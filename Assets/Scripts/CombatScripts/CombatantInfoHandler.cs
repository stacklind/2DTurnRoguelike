using TMPro;
using UnityEngine;

public class CombatantInfoHandler : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI healthInfo;
    [SerializeField]
    private TextMeshProUGUI damageInfo;
    [SerializeField]
    private TextMeshProUGUI critInfo;
    [SerializeField]
    private TextMeshProUGUI statusInfo;

    private void Awake()
    {
        CombatHandler.Events.Subscribe<CombatEvent.BeginPlayerTurnEvent>(UpdateInfo);
    }
    private void UpdateInfo(CombatEvent.BeginPlayerTurnEvent evt)
    {
        healthInfo.text = $"HP: {evt.Combatant.Character.Health.CurrentHealth}/{evt.Combatant.Character.Health.MaxHealth}";
        damageInfo.text = $"DMG: {evt.Combatant.Character.Damage.MinDamage}-{evt.Combatant.Character.Damage.MaxDamage}";
        critInfo.text = $"CRIT: {evt.Combatant.Character.Crit.Chance * 100:F0}% / {evt.Combatant.Character.Crit.Multiplier * 100:F0}%";
        statusInfo.text = "STATUS: <<PLACEHOLDER>>";
    }
}
