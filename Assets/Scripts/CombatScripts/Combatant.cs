using UnityEngine;

public class Combatant : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    public ICharacter Character { get; set; }
    public bool IsPlayer { get; private set; }

    private void Start()
    {
        spriteRenderer.sprite = Character.Visuals.Avatar;

    }

    public void BeginTurn()
    {

    }

    private void Die()
    {
        // TODO play death animation and then set active in different method
        gameObject.SetActive(false);
        Debug.Log($"{Character.Name} has died.");
    }

    public void Initialize(ICharacter c, bool isPlayer)
    {
        Character = c;
        IsPlayer = isPlayer;
    }

    public void TakeDamage(int amount)
    {
        Debug.Log($"{Character.Name} took {amount} damage.");
        bool isDead = Character.Health.ReduceHealth(amount);
        CombatHandler.Events.Publish(new CombatEvent.DamageEvent(amount, this, isDead));

        if (isDead)
        {
            Die();
        }
    }

    public void UseMove(Move move)
    {
        if (!Character.MoveSet.Contains(move))
        {
            throw new System.ArgumentException();
        }

        move.Use(Character);
    }
}
