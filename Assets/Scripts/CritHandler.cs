using UnityEngine;

public class CritHandler
{
    public float Chance { get; set; }
    public float Multiplier { get; set; }

    public CritHandler(float chance, float multiplier)
    {
        Chance = chance;
        Multiplier = multiplier;
    }

    public bool Roll() => Random.Range(0, 100) < Chance * 100;
    public bool Roll(float modifier) => Random.Range(0, 100) < Chance * 100 * modifier;
}