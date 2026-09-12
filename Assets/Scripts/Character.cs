using System.Collections.Generic;
using UnityEngine;

public class Character
{
    private List<Move> moveSet;

    public HealthHandler Health { get; set; }
    public List<Move> MoveSet { get => moveSet; }
    public int Initiative { get; set; }
    public DamageHandler Damage { get; set; }
    public CritHandler Crit { get; set; }
    public Character(int maxHealth, Move[] moves, int initiative, int minDamage, int maxDamage, 
        float criticalChance = 0.05f, float criticalMultiplier = 1.6f)
    {
        Health = new HealthHandler(maxHealth);
        moveSet = new List<Move>(moves);
        Initiative = initiative;
        Damage = new DamageHandler(minDamage, maxDamage);
        Crit = new CritHandler(criticalChance, criticalMultiplier);
    }
}
