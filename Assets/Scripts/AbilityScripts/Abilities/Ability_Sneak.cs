using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "Scriptable Objects/Abilities/Sneak")]
public class Ability_Sneak : Ability
{
    public StatusEffect_Sneak statusEffect;

    private void OnEnable()
    {
        TargetingComponent = new TargetSelfComponent();
        EffectComponents = new[] { new StatusEffectComponent(statusEffect) }; 
    }

    public override string GetTooltip(Combatant user)
    {
        return $"Disengange and sneak around the battlefield, becoming untargetable. While sneaking, you always critical strike.";
    }
}
