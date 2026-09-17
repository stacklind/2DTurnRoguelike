using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCombatStep : CombatStep
{
    public override CombatStep NextStep => null;

    public override void Begin()
    {
        SceneManager.LoadScene("TownScene");
    }
}
