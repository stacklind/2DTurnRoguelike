using UnityEngine;

public class DamageHandler
{
    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }

    public DamageHandler(int minDamage, int maxDamage)
    {
        MinDamage = minDamage;
        MaxDamage = maxDamage;
    }

    public int CalculateDamage(float multiplier)
    {
        return Mathf.FloorToInt(multiplier * Random.Range(MinDamage, MaxDamage + 1));
    }
}
