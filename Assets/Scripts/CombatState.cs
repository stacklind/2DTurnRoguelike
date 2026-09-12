using System.Collections.Generic;

public class CombatState
{
    public List<Combatant> PlayerTeam { get; }
    public List<Combatant> MonsterTeam { get; }
    
    public CombatState(Combatant[] playerTeam, Combatant[] monsterTeam)
    {
        PlayerTeam = new List<Combatant>(playerTeam);
        MonsterTeam = new List<Combatant>(monsterTeam);
    }
}
