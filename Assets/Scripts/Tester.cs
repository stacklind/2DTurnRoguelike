using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tester : MonoBehaviour
{
    void Start()
    {
        ICharacter c0 = new Rogue(19, new[] { new Move_Stab() }, 7, 8, 12);
        ICharacter c1 = new Rogue(15, new Move[0], 11, 8, 12);
        ICharacter c2 = NPCs.Bandit;
        ICharacter c3 = NPCs.Bandit;

        CombatData.Team1 = new List<ICharacter>(new[] { c0, c1});
        CombatData.Team2 = new List<ICharacter>(new[] { c2, c3});

        SceneManager.LoadScene("CombatScene");
    }
}
