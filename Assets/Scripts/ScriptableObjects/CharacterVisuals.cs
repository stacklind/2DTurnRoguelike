using UnityEngine;

[CreateAssetMenu(fileName = "CharacterVisuals", menuName = "Scriptable Objects/CharacterVisuals")]
public class CharacterVisuals : ScriptableObject
{
    [SerializeField]
    private Sprite talkingHead;
    [SerializeField]
    private Sprite avatar;
    public Sprite TalkingHead { get => talkingHead; }
    public Sprite Avatar { get => avatar; }
}
