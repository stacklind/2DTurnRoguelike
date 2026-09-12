public class HealthHandler
{
    public int CurrentHealth { get; set; }
    public int MaxHealth { get; set; }

    public HealthHandler(int maxHealth)
    {
        MaxHealth = CurrentHealth = maxHealth;
    }

    public void ReduceHealth(int amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth < 0)
        {
            CurrentHealth = 0;
        }
    }
}
