using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Transform currentHealth;

    private void OnEnable()
    {
        CombatHandler.Events.Subscribe<CombatEvent.DamageEvent>(HandleDamageEvent);
    }

    private void OnDisable()
    {
        CombatHandler.Events.Unsubscribe<CombatEvent.DamageEvent>(HandleDamageEvent);

    }

    public void HandleDamageEvent(CombatEvent.DamageEvent evt)
    {
        if(evt.Target.transform == gameObject.transform.parent)
        {
            float ratio = (float)evt.Target.Character.Health.CurrentHealth / (float)evt.Target.Character.Health.MaxHealth;
            currentHealth.localScale = new Vector3(ratio, 1, 1);
        }
    }
}
