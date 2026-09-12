public class Move_Stab : Move, IDealsDamage, ICanCrit
{
    public override string Name { get; } = "Stab";
    public float DamageModifier { get; set; } = 0.9f;
    public float CritChanceModifier { get; set; } = 1.5f;

    public Move_Stab()
    { 
    }

    public override void Use(Character character)
    {
        float finalModifier = character.Crit.Roll(CritChanceModifier) ? DamageModifier * character.Crit.Multiplier : DamageModifier;
        CombatHandler.State.MonsterTeam[0].TakeDamage(character.Damage.CalculateDamage(finalModifier));
    }
}
