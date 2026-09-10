using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tester : MonoBehaviour
{
    void Start()
    {
        Character c0 = new Character(19, 3, new[] { new Move_Stab() }, 7, 8);
        Character c1 = new Character(15, 4, new Move[0], 11, 8);
        Character c2 = new Character(11, 4, new Move[0], 2, 8);
        Character c3 = new Character(23, 2, new Move[0], 4, 8);

        CombatData.Team1 = new List<Character>(new[] { c0, c1});
        CombatData.Team2 = new List<Character>(new[] { c2, c3});

        SceneManager.LoadScene("CombatScene");
    }
}
