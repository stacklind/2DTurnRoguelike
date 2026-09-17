using System.Collections.Generic;

public class CombatState
{
    public List<Combatant> PlayerTeam { get; }
    public List<Combatant> MonsterTeam { get; }

    public bool IsOver => PlayerTeam.Count == 0 || MonsterTeam.Count == 0;

    public CombatState(Combatant[] playerTeam, Combatant[] monsterTeam)
    {
        PlayerTeam = new List<Combatant>(playerTeam);
        MonsterTeam = new List<Combatant>(monsterTeam);
        CombatHandler.Events.Subscribe<CombatEvent.DeathEvent>(OnDeath);
    }

    private void OnDeath(CombatEvent.DeathEvent evt)
    {
        if (evt.Combatant.IsPlayer)
        {
            PlayerTeam.Remove(evt.Combatant);
        }
        else
        {
            MonsterTeam.Remove(evt.Combatant);
        }
    }
}
