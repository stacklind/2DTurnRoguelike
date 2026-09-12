using System.Collections.Generic;
using UnityEngine;

public class Rogue : ICharacter
{
    public HealthHandler Health { get; }
    public List<Move> MoveSet { get; }
    public int Initiative { get; set; }
    public DamageHandler Damage { get; }
    public CritHandler Crit { get; }
    public Sprite TalkingHead { get; }
    public Sprite Avatar { get; }

    public Rogue(int maxHealth, Move[] moves, int initiative, int minDamage, int maxDamage, float criticalChance = 0.05F, float criticalMultiplier = 1.6F)
    {
        Health = new HealthHandler(maxHealth);
        MoveSet = new List<Move>(moves);
        Initiative = initiative;
        Damage = new DamageHandler(minDamage, maxDamage);
        Crit = new CritHandler(criticalChance, criticalMultiplier);
        TalkingHead = Resources.Load<Sprite>("rogue_talking_head");
        Avatar = Resources.Load<Sprite>("rogue_avatar");
    }
}
