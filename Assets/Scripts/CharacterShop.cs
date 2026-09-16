using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterShop : MonoBehaviour
{
    [SerializeField]
    private CharacterShopOption[] characterShopOptions;

    private int selectedIndex;

    private void Awake()
    {
        for (int i = 0; i < characterShopOptions.Length; i++)
        {
            characterShopOptions[i].Character = Rogue.RandomlyGenerate();
        }
    }

    public void CharacterSelected(int index)
    {
        selectedIndex = index;
        TownHandler.Events.Publish(new TownEvent.CharacterSelectedEvent(characterShopOptions[index].Character));
    }

    public void Hire()
    {
        if(CombatLoadData.Team1.Count < 4)
        {
            characterShopOptions[selectedIndex].Hire();
        }
        else
        {
            TownHandler.Events.Publish(new TownEvent.WarningEvent("Can not hire more characters. Team is full!"));
        }
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
