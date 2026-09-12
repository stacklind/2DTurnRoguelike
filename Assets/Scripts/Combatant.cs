using UnityEngine;

public class Combatant : MonoBehaviour
{
    public Character Character { get; set; }
    public bool IsPlayer { get; private set; }

    public void TakeDamage(int amount)
    {
        Character.Health.ReduceHealth(amount);
        CombatHandler.Events.Publish(new CombatEvent.DamageEvent(amount, this));
    }

    public void Initialize(Character c, bool isPlayer)
    {
        Character = c;
        IsPlayer = isPlayer;
    }

    public void UseMove(int index)
    {
        Character.MoveSet[index].Use(Character);
        CombatHandler.Events.Publish(new CombatEvent.EndTurnEvent(this));
    }
}
