using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Transform currentHealth;

    private float target;
    private float current;
    private float step;

    private void OnEnable()
    {
        target = current = 1f;
        step = 0;
        CombatHandler.Events.Subscribe<CombatEvent.DamageEvent>(HandleDamageEvent);
    }

    private void OnDisable()
    {
        CombatHandler.Events.Unsubscribe<CombatEvent.DamageEvent>(HandleDamageEvent);

    }

    private void Update()
    {
        if(target != current)
        {
            step += 0.5f * Time.deltaTime;
            float temp = Mathf.Lerp(current, target, step);
            currentHealth.localScale = new Vector3(temp, 1f, 1f);

            if (step > 1.0f)
            {
                current = target;
                step = 0;
            }
        }
    }

    public void HandleDamageEvent(CombatEvent.DamageEvent evt)
    {
        if(evt.Target.transform == gameObject.transform.parent)
        {
            float ratio = (float)evt.Target.Character.Health.CurrentHealth / (float)evt.Target.Character.Health.MaxHealth;
            target = Mathf.Round(ratio * 100f) / 100f;
        }
    }
}
