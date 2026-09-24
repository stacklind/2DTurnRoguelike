using System.Collections.Generic;

public static class CombatLoadData
{
    public static List<Character> Team1;
    public static List<Character> Team2;

    public static void Refresh()
    {
        Team1 = new List<Character>();
        Team1.Add(new Character(Constants.Instance.PlayableBases[0]));
        Team1.Add(new Character(Constants.Instance.PlayableBases[0]));
        Team2 = new List<Character>();
        Team2.Add(new Character(Constants.Instance.MonsterBases[0]));
        Team2.Add(new Character(Constants.Instance.MonsterBases[0]));
    }
}
