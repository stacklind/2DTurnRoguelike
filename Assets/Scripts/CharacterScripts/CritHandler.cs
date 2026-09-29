using UnityEngine;

public class CritHandler
{
    private int _alwaysCrit = 0;
    public float Chance { get; set; }
    public float Multiplier { get; set; }
    public bool AlwaysCrit 
    {
        get => _alwaysCrit > 0;
        set
        {
            bool tmp = value;
            if(tmp)
            {
                _alwaysCrit++;
            }
            else
            {
                _alwaysCrit--;
            }
        }
    }

    public CritHandler(float chance, float multiplier)
    {
        Chance = chance;
        Multiplier = multiplier;
    }

    public float Roll() => Roll(1f);
    //public float Roll(float modifier) => AlwaysCrit || Random.Range(0, 100) < Chance * 100 * modifier ? Multiplier : 1f;
    public float Roll(float modifier)
    {
        int result = Random.Range(0, 100);

        if(AlwaysCrit || result < Chance * 100 * modifier)
        {
            Debug.Log("CRIT!");
            return Multiplier;
        }

        return 1f;
    }
}