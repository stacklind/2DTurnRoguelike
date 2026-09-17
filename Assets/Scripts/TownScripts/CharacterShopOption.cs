using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterShopOption : MonoBehaviour
{
    [SerializeField]
    private Image characterImage;
    [SerializeField]
    private TextMeshProUGUI characterName;
    [SerializeField]
    private TextMeshProUGUI characterMoves;

    private ICharacter _character;
    public ICharacter Character 
    {
        get => _character;
        set
        {
            _character = value;
            UpdateCharacterImage();
            UpdateCharacterName();
            UpdateCharacterMoves();
        } 
    }

    private void UpdateCharacterImage()
    {
        characterImage.sprite = _character.Visuals.TalkingHead;
    }

    private void UpdateCharacterName()
    {
        characterName.text = _character.Name;
    }
    private void UpdateCharacterMoves()
    {
        string text = "Moves:";
        for(int i = 0; i < _character.MoveSet.Count; i++)
        {
            text += $" {_character.MoveSet[i].Name} |";
        }
        text = text.Substring(0, text.Length - 1);
        characterMoves.text = text;
    }

    public void Hire()
    {
        characterImage.sprite = Resources.Load<Sprite>("sold");
        characterName.text = "SOLD!";
        characterMoves.text = "";
        gameObject.GetComponent<Button>().interactable = false;
        CombatLoadData.Team1.Add(_character);
        TownHandler.Events.Publish(new TownEvent.CharacterConfirmedEvent(_character));
    }
}
