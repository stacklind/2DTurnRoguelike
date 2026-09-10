using UnityEngine;

public class Combatant
{
    private CombatantMono mono;
    private Healthbar healthBar;

    public Character Character { get; }
    public bool IsPlayer { get; }

    public Combatant(Character character, bool isPlayer, CombatantMono mono)
    {
        Character = character;
        IsPlayer = isPlayer;
        this.mono = mono;
    }

    public void Damage(int amount)
    {
        Character.CurrentHealth = Character.CurrentHealth - amount < 0 ? 0 : Character.CurrentHealth - amount;

        mono.HealthBar.UpdateHealthbar((float) Character.CurrentHealth / Character.MaxHealth);

        if(Character.CurrentHealth == 0)
        {
            Die();
        }
    }

    private void Die()
    {

    }
}
