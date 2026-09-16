using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    // Stats
    public string Name { get; }
    public HealthHandler Health { get; }
    public List<Move> MoveSet { get; }
    public int Initiative { get; set; }
    public DamageHandler Damage { get; }
    public CritHandler Crit { get; }

    // Visuals
    public Sprite TalkingHead { get; }
    public Sprite Avatar { get; }

    // Audio
    public CharacterAudio Audio { get; }
}
