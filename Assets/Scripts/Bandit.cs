using System.Collections.Generic;
using UnityEngine;

public class Bandit : ICharacter
{
    public string Name { get; }
    public HealthHandler Health { get; }
    public List<Move> MoveSet { get; }
    public int Initiative { get; set; }
    public DamageHandler Damage { get; }
    public CritHandler Crit { get; }
    public Sprite TalkingHead { get; }
    public Sprite Avatar { get; }

    public CharacterAudio Audio => throw new System.NotImplementedException();

    public Bandit()
    {
        Name = "Bandit";
        Health = new HealthHandler(11);
        MoveSet = new List<Move>();
        MoveSet.Add(new BanditAttack());
        Initiative = 5;
        Damage = new DamageHandler(4, 6);
        Crit = new CritHandler(0, 1.0f);
        TalkingHead = Resources.Load<Sprite>("bandit_talking_head");
        Avatar = Resources.Load<Sprite>("bandit_avatar");
    }

    public class BanditAttack : Move, IDealsDamage
    {
        public override string Name { get; } = "Bandit attack";
        public float DamageModifier { get; set; } = 1.0f;

        public override void Use(ICharacter character)
        {
            CombatHandler.State.PlayerTeam[0].TakeDamage(character.Damage.CalculateDamage(DamageModifier));
        }
    }
}
