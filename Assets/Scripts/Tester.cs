using UnityEngine;
using UnityEngine.SceneManagement;

public class Tester : MonoBehaviour
{
    void Start()
    {
        Character c0 = new Character(19, 3, new Move[0], 7);
        Character c1 = new Character(15, 4, new Move[0], 11);
        Character c2 = new Character(11, 4, new Move[0], 2);
        Character c3 = new Character(23, 2, new Move[0], 4);

        CombatData.CreateTeamOne(new[] { new Combatant(c0, true), new Combatant(c1, true) });
        CombatData.CreateTeamTwo(new[] { new Combatant(c2, false), new Combatant(c3, false) });

        SceneManager.LoadScene("CombatScene");
    }
}
