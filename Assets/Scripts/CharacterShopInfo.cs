using TMPro;
using UnityEngine;

public class CharacterShopInfo : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI characterName;
    [SerializeField]
    private TextMeshProUGUI characterStats;
    [SerializeField]
    private TextMeshProUGUI characterMoves;

    private void OnEnable()
    {
        ResetInfo();
        TownHandler.Events.Subscribe<TownEvent.CharacterSelectedEvent>(DisplayCharacterInfo);
    }

    private void OnDisable()
    {
        TownHandler.Events.Unsubscribe<TownEvent.CharacterSelectedEvent>(DisplayCharacterInfo);
    }

    private void ResetInfo()
    {
        characterName.text = "";
        characterStats.text = "";
        characterMoves.text = "";
    }

    private void DisplayCharacterInfo(TownEvent.CharacterSelectedEvent evt)
    {
        characterName.text = evt.Character.Name;
        characterStats.text = $"HP: {evt.Character.Health.MaxHealth}\n" +
                                $"Initiative: {evt.Character.Initiative}\n" +
                                $"Damage: {evt.Character.Damage.MinDamage}-{evt.Character.Damage.MaxDamage}\n" +
                                $"Crit: {evt.Character.Crit.Chance * 100}%/{evt.Character.Crit.Multiplier}x";
        characterMoves.text = "";
        for(int i = 0; i < evt.Character.MoveSet.Count; i++)
        {
            characterMoves.text += evt.Character.MoveSet[i].Name + "\n";
        }
        characterMoves.text = characterMoves.text.Substring(0, characterMoves.text.Length - 1);
    }
}
