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
        healthInfo.text = "";
        damageInfo.text = "";
        critInfo.text = "";
        statusInfo.text = "";
    }

    private void Start()
    {
        CombatHandler.Events.Subscribe<CombatEvent.BeginTurnEvent>(HandleBTE);
    }

    private void HandleBTE(CombatEvent.BeginTurnEvent evt)
    {
        if(evt.Combatant.IsPlayer)
        {
            UpdateInfo(evt.Combatant);
        }
    }

    private void UpdateInfo(Combatant combatant)
    {
        healthInfo.text = $"HP: {combatant.Character.Health.CurrentHealth}/{combatant.Character.Health.MaxHealth}";
        damageInfo.text = $"DMG: {combatant.Character.Damage.MinDamage}-{combatant.Character.Damage.MaxDamage}";
        critInfo.text = $"CRIT: {combatant.Character.Crit.Chance * 100:F0}% / {combatant.Character.Crit.Multiplier * 100:F0}%";
        statusInfo.text = "STATUS: <<PLACEHOLDER>>";
    }
}
