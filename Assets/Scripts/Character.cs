using System.Collections.Generic;

public class Character
{
    private List<Move> moveSet;

    public List<Move> MoveSet { get => moveSet; }
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }
    public int MaxEnergy { get; set; }
    public int CurrentEnergy { get; set; }
    public int Initiative { get; set; }

    public int Damage { get; set; }
    public Character(int maxHealth, int maxEnergy, Move[] moves, int initiative, int damage)
    {
        MaxHealth = CurrentHealth = maxHealth;
        MaxEnergy = CurrentEnergy = maxEnergy;
        moveSet = new List<Move>(moves);
        Initiative = initiative;
        Damage = damage;
    }
}
