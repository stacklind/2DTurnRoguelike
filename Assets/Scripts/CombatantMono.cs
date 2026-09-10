using UnityEngine;

public class CombatantMono : MonoBehaviour
{
    [SerializeField]
    private Healthbar healthBar;

    public Healthbar HealthBar { get { return healthBar; } }
}
