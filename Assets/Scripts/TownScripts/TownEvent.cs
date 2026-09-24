using UnityEngine;

public class TownEvent
{
    public class CharacterSelectedEvent
    {
        public readonly Character Character;

        public CharacterSelectedEvent(Character character)
        {
            Character = character;
        }
    }

    public class CharacterConfirmedEvent
    {
        public readonly Character Character;

        public CharacterConfirmedEvent(Character character)
        {
            Character = character;
        }
    }

    public class WarningEvent
    {
        public readonly string Text;

        public WarningEvent(string text)
        {
            Text = text;
            Debug.Log(text);
        }
    }
}
