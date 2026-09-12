public abstract class Move
{
    public abstract string Name { get; }

    public Move() 
    {  
    }

    public abstract void Use(ICharacter character);
}
