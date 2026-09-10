using UnityEngine;

public class Move_Stab : Move
{
    public override string Name { get; } = "Stab";
    public override int EnergyCost { get; set; } = 2;
    public float Damage { get; set; } = 0.9f;

    public Move_Stab() { }

    public override void Use(CombatHandler ch, Character c)
    {
        Combatant target = ch.GetMonsterTeam()[0];
        target.Damage(Mathf.FloorToInt(Damage * c.Damage));
    }
}
