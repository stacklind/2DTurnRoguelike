using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ability_Sneak : Ability
{
    //public override string Name => "Sneak";
    //public override Positions DefaultTargets => Positions.None;

    //public override void Use(Combatant user)
    //{
    //    user.ApplyBuff(new Move_Sneak.Buff(Name, 1, 1, SEType.Trigger));
    //}

    //public class Buff : StatusEffect
    //{
    //    private List<Ability> modifiedMoves = new List<Ability>();


    //    public override int StrengthScore => maxStacks;

    //    public override Sprite Icon { get; }

    //    public Buff(string name, int initialStacks, int maxStacks, SEType type) : base(name, initialStacks, maxStacks, type) 
    //    {
    //        Icon = Resources.Load<Sprite>("buff_sneak");
    //    }

    //    public void Use()
    //    {
    //        Stacks--;
    //        CombatHandler.Events.Unsubscribe<CombatEvent.EndTurnEvent>(e => Use());
    //    }

    //    protected override void ApplyInternal(Combatant combatant)
    //    {
    //        combatant.Character.MoveSet.ForEach(x => ModifyMoveTargets(x));
    //        combatant.Character.Crit.AlwaysCrit = true;
    //        CombatHandler.Events.Subscribe<CombatEvent.MoveChosenEvent>(HandleMoveChosenEvent);
    //    }

    //    private void ModifyMoveTargets(Ability m)
    //    {
    //        if(m.DefaultTargets != Positions.None)
    //        {
    //            m.ValidTargets = Positions.All;
    //            modifiedMoves.Add(m);
    //        }
    //    }

    //    private void HandleMoveChosenEvent(CombatEvent.MoveChosenEvent evt)
    //    {
    //        if(modifiedMoves.Contains(evt.Move))
    //        {
    //            CombatHandler.Events.Subscribe<CombatEvent.EndTurnEvent>(e => Use());
    //        }
    //    }

    //    protected override void RemoveInternal(Combatant combatant)
    //    {
    //        modifiedMoves.ForEach(x => UnmodifiyMoveTargets(x));
    //        combatant.Character.Crit.AlwaysCrit = false;
    //        CombatHandler.Events.Unsubscribe<CombatEvent.MoveChosenEvent>(HandleMoveChosenEvent);
    //    }

    //    private void UnmodifiyMoveTargets(Ability m)
    //    {
    //        m.ValidTargets = m.DefaultTargets;
    //    }
    //}
    public override string GetTooltip(Combatant user)
    {
        throw new System.NotImplementedException();
    }
}
