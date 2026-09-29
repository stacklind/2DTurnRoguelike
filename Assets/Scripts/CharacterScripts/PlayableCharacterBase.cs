using UnityEngine;

[CreateAssetMenu(menuName="Scriptable Objects/Character Base/Playable Character")]
public class PlayableCharacterBase : ScriptableObject
{
    [Header("Info")]
    public string[] Names;
    public Ability[] Abilities;

    [Header("Stats")]
    public FromTo<int> Health;
    public FromTo<int> Initiative;
    public FromTo<int> MinDamage;
    public FromTo<int> MaxDamageAddition;
    public FromTo<float> CritChance;
    public FromTo<float> CritMultiplier;


    [Header("Visuals")]
    public CharacterVisuals Visuals;

    [Header("Audio")]
    public PlayableCharacterAudio Audio;
}

[System.Serializable]
public class FromTo<T>
{
    public T From;
    public T To;
}