using UnityEngine;

public class Ability_PoisonedDart : Ability
{
    //private readonly int DEFAULT_DURATION = 3;
    //private readonly int DEFAULT_REDUCTION = 5;
    //public override string Name => "Poisoned Dart";
    //public override Positions DefaultTargets => Positions.All;

    //public override void Use(Combatant user)
    //{
    //    // Temporary targeting implementation
    //    CombatHandler.State.MonsterTeam[0].ApplyDebuff(new Move_PoisonedDart.Debuff(Name, DEFAULT_DURATION, SEType.Duration, DEFAULT_REDUCTION));
    //}

    //public class Debuff : StatusEffect
    //{
    //    private readonly int REDUCTION_AMOUNT;

    //    public override int StrengthScore => REDUCTION_AMOUNT;

    //    public override Sprite Icon { get; }

    //    public Debuff(string name, int initialStacks, SEType type, int reductionAmount) : base(name, initialStacks, type)
    //    {
    //        REDUCTION_AMOUNT = reductionAmount;
    //        Icon = Resources.Load<Sprite>("debuff_poisoned_dart");
    //    }

    //    protected override void ApplyInternal(Combatant combatant)
    //    {
    //        combatant.Character.Initiative -= REDUCTION_AMOUNT;
    //    }

    //    protected override void RemoveInternal(Combatant combatant)
    //    {
    //        combatant.Character.Initiative += REDUCTION_AMOUNT;
    //    }
    //}
    public override string GetTooltip(Combatant user)
    {
        throw new System.NotImplementedException();
    }
}


