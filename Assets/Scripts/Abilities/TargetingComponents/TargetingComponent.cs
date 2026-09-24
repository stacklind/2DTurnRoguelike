using UnityEngine;

public abstract class TargetingComponent
{
    public void AquireTargets(Combatant user)
    {
        Debug.Log("TargetingComponent > AquireTargets");
        Combatant[] possibleTargets = GetPossibleTargets(user);
        TargetingPackage package = new TargetingPackage
        {
            User = user,
            PossibleTargets = possibleTargets
        };

        CombatHandler.Events.Subscribe<CombatEvent.AbilityConfirmedEvent>(HandleConfirmationEvent);
        CombatHandler.Events.Publish(new CombatEvent.AquireTargetsEvent(package));
    }

    protected abstract Combatant[] GetPossibleTargets(Combatant user);

    protected abstract Combatant[] GetFinalTargets(Combatant user, Combatant[] possibleTargets, Combatant clicked);

    private void HandleConfirmationEvent(CombatEvent.AbilityConfirmedEvent evt)
    {
        Debug.Log("TargetingComponent > HandleConfirmationEvent");
        CombatHandler.Events.Unsubscribe<CombatEvent.AbilityConfirmedEvent>(HandleConfirmationEvent);
        FinalizeTargets(evt.Package);
    }
    private void FinalizeTargets(TargetingPackage package)
    {
        Debug.Log("TargetingComponent > FinalizeTargets");
        Combatant[] finalTargets = GetFinalTargets(package.User, package.PossibleTargets, package.Clicked);
        CombatHandler.Events.Publish(new CombatEvent.TargetsAquiredEvent(package.User, finalTargets));
    }
}

public class TargetingPackage
{
    public Combatant User;
    public Combatant[] PossibleTargets;
    public Combatant Clicked;
}