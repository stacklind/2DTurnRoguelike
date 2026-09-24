
public interface IEffectComponent
{
    public void ApplyEffect(Combatant user, Combatant target);

    public enum EKeyword
    {
        Damage
    }
}
