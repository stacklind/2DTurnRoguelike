using UnityEditor.Animations;
using UnityEngine;

public class Move_Stab : Move, IDealsDamage, ICanCrit
{
    public override string Name { get; }

    public float DamageModifier { get; } = 0.9f;
    public float CritChanceModifier { get; } = 1.5f;

    

    public Move_Stab()
    {
        Name = "Stab";
    }

    public override void Use(ICharacter character)
    {
        float finalModifier = character.Crit.Roll(CritChanceModifier) ? DamageModifier * character.Crit.Multiplier : DamageModifier;
        CombatHandler.State.MonsterTeam[0].TakeDamage(character.Damage.CalculateDamage(finalModifier));
    }
}
