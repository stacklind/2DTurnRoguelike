using System.Collections.Generic;

public static class CombatLoadData
{
    public static List<ICharacter> Team1;
    public static List<ICharacter> Team2;

    public static void Refresh()
    {
        Team1 = new List<ICharacter>();
        Team2 = new List<ICharacter>();
    }
}
