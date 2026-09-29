using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable Objects/Character Base/Monster")]
public class MonsterBase : ScriptableObject
{
    [Header("Info")]
    public string Name;
    public Ability[] Abilities;

    [Header("Stats")]
    public int MaxHealth;
    public int Initiative;
    public int MinDamage;
    public int MaxDamage;
    public float CritChance;
    public float CritMultiplier;

    [Header("Visuals")]
    public CharacterVisuals Visuals;
}
