using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

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

    public void ApplyBuff(StatusEffectInstance buff)
    {
        buffs.Add(buff);
    }

    public void ApplyDebuff(StatusEffectInstance debuff)
    {
        debuffs.Add(debuff);
    }

    public void Initialize(Character c, bool isPlayer)
    {
        Character = c;
        IsPlayer = isPlayer;

        buffs = new StatusEffectHandler(_UI.BuffHandler, this);
        debuffs = new StatusEffectHandler(_UI.DebuffHandler, this);

        _UI.Initialize(this);
        _UI.Enable();

        spriteRenderer.sprite = Character.Visuals.Avatar;
        gameObject.SetActive(true);
    }

    public void RemoveBuff(StatusEffectInstance buff)
    {
        buffs.Remove(buff);
    }

    public void RemoveDebuff(StatusEffectInstance debuff)
    {
        debuffs.Remove(debuff);
    }

    public void TakeDamage(int amount, Combatant source)
    {
        bool isDead = Character.Health.ReduceHealth(amount);
        _UI.UpdateHealthBar(Character.Health.Ratio);

        CombatHandler.Events.Publish(new CombatEvent.DamageEvent(amount, source, this, isDead));

        if (isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        // TODO play death animation and then set active in different method
        CombatHandler.Events.Publish(new CombatEvent.DeathEvent(this));
        _UI.Disable();
        gameObject.SetActive(false);
    }
}
