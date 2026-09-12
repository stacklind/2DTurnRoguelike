using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    public HealthHandler Health { get; }
    public List<Move> MoveSet { get; }
    public int Initiative { get; set; }
    public DamageHandler Damage { get; }
    public CritHandler Crit { get; }
    public Sprite TalkingHead { get; }
    public Sprite Avatar { get; }
}
