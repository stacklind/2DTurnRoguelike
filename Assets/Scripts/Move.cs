public abstract class Move
{
    public abstract string Name { get; }
    public abstract int EnergyCost { get; set; }

    public Move() { }

    public abstract void Use(CombatHandler ch, Character c);
}
