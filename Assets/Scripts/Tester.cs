using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tester : MonoBehaviour
{
    void Start()
    {
        Character c0 = new Character(19, new[] { new Move_Stab() }, 7, 8, 12);
        Character c1 = new Character(15, new Move[0], 11, 8, 12);
        Character c2 = new Character(11, new Move[0], 2, 8, 12);
        Character c3 = new Character(23, new Move[0], 4, 8, 12);

        CombatData.Team1 = new List<Character>(new[] { c0, c1});
        CombatData.Team2 = new List<Character>(new[] { c2, c3});

        SceneManager.LoadScene("CombatScene");
    }
}
