using UnityEngine;
using System.Collections.Generic;

public class Combatant : MonoBehaviour
{
    [SerializeField]
    private CombatantUI _UI;

    private SpriteRenderer spriteRenderer;
    private StatusEffectHandler buffs;
    private StatusEffectHandler debuffs;

    private int _isTargetable = 1;

    public Character Character { get; private set; }
    public bool IsPlayer { get; private set; }
    public bool IsTargetable
    {
        get => _isTargetable > 0;
        set
        {
            if(value)
            {
                _isTargetable++;
            }
            else
            {
                _isTargetable--;
            }
        }
    }
    public CombatantUI UI => _UI;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void ApplyBuff(StatusEffect buff)
    {
        Debug.Log("Combatant > ApplyBuff");
        buff.Apply(this);
        buffs.Add(buff);
    }

    public void ApplyDebuff(StatusEffect debuff)
    {
        Debug.Log("Combatant > ApplyDebuff");
        debuff.Apply(this);
        debuffs.Add(debuff);
    }

    public void Initialize(Character c, bool isPlayer)
    {
        Debug.Log("Combatant > Initialize");
        Character = c;
        IsPlayer = isPlayer;

        buffs = new StatusEffectHandler(_UI.BuffHandler);
        debuffs = new StatusEffectHandler(_UI.DebuffHandler);

        _UI.Initialize(this);
        _UI.Enable();

        spriteRenderer.sprite = Character.Visuals.Avatar;
        gameObject.SetActive(true);

        InitializeEvents();
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("Combatant > TakeDamage");
        bool isDead = Character.Health.ReduceHealth(amount);
        _UI.UpdateHealthBar(Character.Health.Ratio);

        CombatHandler.Events.Publish(new CombatEvent.DamageEvent(amount, this, isDead));

        if (isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Combatant > Die");
        // TODO play death animation and then set active in different method
        buffs.Clear();
        debuffs.Clear();
        _UI.Disable();
        UnsubscribeFromEvents();
        gameObject.SetActive(false);
    }

    private void InitializeEvents()
    {
        CombatHandler.Events.Subscribe<CombatEvent.EndTurnEvent>(HandleEndTurnEvent);
    }

    private void HandleEndTurnEvent(CombatEvent.EndTurnEvent evt)
    {
        if(evt.CurrentCombatant == this)
        {
            evt.Step.CompleteTask();
        }
    }

    private void UnsubscribeFromEvents()
    {
        CombatHandler.Events.Unsubscribe<CombatEvent.EndTurnEvent>(HandleEndTurnEvent);
    }
}
