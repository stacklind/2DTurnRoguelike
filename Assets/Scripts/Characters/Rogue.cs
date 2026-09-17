using System.Collections.Generic;
using UnityEngine;

public class Rogue : ICharacter, IRandomlyGenerated<Rogue>
{
    public string Name { get; }

    public HealthHandler Health { get; }
    public List<Move> MoveSet { get; }
    public int Initiative { get; set; }
    public DamageHandler Damage { get; }
    public CritHandler Crit { get; }

    public CharacterVisuals Visuals { get; }

    public CharacterAudio Audio { get; }

    public Rogue(string name, int maxHealth, Move[] moves, int initiative, int minDamage, int maxDamage, float criticalChance = 0.05F, float criticalMultiplier = 1.6F)
    {
        Name = name;
        Health = new HealthHandler(maxHealth);
        MoveSet = new List<Move>(moves);
        Initiative = initiative;
        Damage = new DamageHandler(minDamage, maxDamage);
        Crit = new CritHandler(criticalChance, criticalMultiplier);

        Visuals = Resources.Load<CharacterVisuals>("rogue_visuals");

        Audio = Resources.Load<PlayableCharacterAudio>("rogue_audio");
    }

    public static Rogue RandomlyGenerate()
    {
        string name = "Rogue test";
        Move[] moves = new[] { new Move_Stab() };
        int health = Random.Range(12, 18);
        int initiative = Random.Range(3, 11);
        int minDamage = Random.Range(2, 6);
        int maxDamage = Random.Range(minDamage + 1, minDamage + 5);
        float critChance = (float)Random.Range(5, 9) / 100;
        float critMulti = (float)Random.Range(16, 19) / 10;

        return new Rogue(name, health, moves, initiative, minDamage, maxDamage, critChance, critMulti);
    }
}
