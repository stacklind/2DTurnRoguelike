public abstract class Move
{
    public int EnergyCost { get; private set; }

    public Move(int energyCost)
    {
        EnergyCost = energyCost;
    }

    public abstract void Use();
}
