using System;
using Unity.VisualScripting;
using UnityEngine;

public class CombatantUI : MonoBehaviour
{
    private HealthBar healthBar;
    
    public StatusEffectHandlerUI BuffHandler { get; private set; }
    public StatusEffectHandlerUI DebuffHandler { get; private set; }
    public Hitbox HitBox { get; private set; }

    private void Awake()
    {
        healthBar = GetComponentInChildren<HealthBar>();
        HitBox = GetComponentInChildren<Hitbox>();
        BuffHandler = transform.Find("StatusEffects/Buffs").GetComponent<StatusEffectHandlerUI>();
        DebuffHandler = transform.Find("StatusEffects/Debuffs").GetComponent<StatusEffectHandlerUI>();
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Initialize(Combatant c)
    {
        HitBox.Initialize(c);
        UpdateHealthBar(c.Character.Health.Ratio);
    }

    public void UpdateHealthBar(float ratio)
    {
        Debug.Log("CombatantUI > UpdateHealthBar");
        healthBar.Ratio = ratio;
    }
}
