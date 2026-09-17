using UnityEngine;

public class TownEvent
{
    public class CharacterSelectedEvent
    {
        public readonly ICharacter Character;

        public CharacterSelectedEvent(ICharacter character)
        {
            Character = character;
        }
    }

    public class CharacterConfirmedEvent
    {
        public readonly ICharacter Character;

        public CharacterConfirmedEvent(ICharacter character)
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
