using System.Collections.Generic;

public static class CombatData
{
    public static List<Combatant> Team1;
    public static List<Combatant> Team2;

    public static void CreateTeamOne(Combatant[] participants)
    {
        Team1 = new List<Combatant>(participants);
    }

    public static void CreateTeamTwo(Combatant[] participants)
    {
        Team2 = new List<Combatant>(participants);
    }
}
