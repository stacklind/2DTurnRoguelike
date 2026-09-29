using System.Collections.Generic;

public class CombatState
{
    private List<Combatant> _playerTeam;
    private List<Combatant> _monsterTeam;

    public bool IsOver => _playerTeam.Count == 0 || _monsterTeam.Count == 0;

    public CombatState(Combatant[] playerTeam, Combatant[] monsterTeam)
    {
        _playerTeam = new List<Combatant>(playerTeam);
        _monsterTeam = new List<Combatant>(monsterTeam);
        CombatHandler.Events.Subscribe<CombatEvent.DeathEvent>(OnDeath);
    }

    public Combatant[] GetOpponentTeam(Combatant c) => c.IsPlayer ? _monsterTeam.ToArray() : _playerTeam.ToArray();
    public Combatant[] GetSameTeam(Combatant c) => c.IsPlayer ? _playerTeam.ToArray() : _monsterTeam.ToArray();

    private void OnDeath(CombatEvent.DeathEvent evt)
    {
        if (evt.Combatant.IsPlayer)
        {
            _playerTeam.Remove(evt.Combatant);
        }
        else
        {
            _monsterTeam.Remove(evt.Combatant);
        }
    }
}
