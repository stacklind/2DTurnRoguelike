using UnityEngine;

[CreateAssetMenu(fileName = "PlayableCharacterAudio", menuName = "Scriptable Objects/Audio/PlayableCharacter")]
public class PlayableCharacterAudio : CharacterAudio
{
    [SerializeField]
    private AudioClip selected;
    [SerializeField]
    private AudioClip confirmed;

    public AudioClip Selected { get => selected; }
    public AudioClip Confirmed { get => confirmed; }
}
