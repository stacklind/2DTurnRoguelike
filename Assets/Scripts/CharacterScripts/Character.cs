using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Character
{
    // Stats
    public string Name { get; }
    public HealthHandler Health { get; }
    public List<Ability> Abilities { get; }
    public int Initiative { get; set; }
    public DamageHandler Damage { get; }
    public CritHandler Crit { get; }

    // Visuals
    public CharacterVisuals Visuals { get; }

    // Audio
    public CharacterAudio Audio { get; }

    public Character(PlayableCharacterBase characterBase)
    {
        Name = characterBase.Names[Random.Range(0, characterBase.Names.Length)];
        Health = new HealthHandler(Random.Range(characterBase.Health.From, characterBase.Health.To));
        
        Abilities = new List<Ability>();
        foreach(Ability a in characterBase.Abilities)
        {
            Abilities.Add(ScriptableObject.Instantiate(a)); // Make an instance so we dont accidentally manipulate the original later on.
        }

        Initiative = Random.Range(characterBase.Initiative.From, characterBase.Initiative.To);

        int minDamage = Random.Range(characterBase.MinDamage.From, characterBase.MinDamage.To);
        Damage = new DamageHandler(
            minDamage, 
            minDamage + Random.Range(characterBase.MaxDamageAddition.From, characterBase.MaxDamageAddition.To));
        Crit = new CritHandler(
            Random.Range(characterBase.CritChance.From, characterBase.CritChance.To),
            Random.Range(characterBase.CritMultiplier.From, characterBase.CritMultiplier.To));

        Visuals = characterBase.Visuals;
        Audio = characterBase.Audio;
    }

    public Character(MonsterBase monsterBase)
    {
        Name = monsterBase.Name;
        Health = new HealthHandler(monsterBase.MaxHealth);

        Abilities = new List<Ability>();
        foreach (Ability a in monsterBase.Abilities)
        {
            Abilities.Add(ScriptableObject.Instantiate(a)); // Make an instance so we dont accidentally manipulate the original later on.
        }

        Initiative = monsterBase.Initiative;

        Damage = new DamageHandler(
            monsterBase.MinDamage, 
            monsterBase.MaxDamage);
        Crit = new CritHandler(
            monsterBase.CritChance, 
            monsterBase.CritMultiplier);

        Visuals = monsterBase.Visuals;
    }
}
