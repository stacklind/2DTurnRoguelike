public class Combatant
{
    public Character Character { get; }
    public bool IsPlayer { get; }

    public Combatant(Character character, bool isPlayer)
    {
        Character = character;
        IsPlayer = isPlayer;
    }

    public void UseMove(int index)
    {
        Move move = Character.MoveSet[index];
        Character.CurrentEnergy -= move.EnergyCost;
        move.Use();
    }
}
