using UnityEngine;
using UnityEngine.EventSystems;

public class Hitbox : MonoBehaviour, ISelectHandler
{
    private Combatant myCombatant;
    private TargetingPackage currentPackage;

    public void Activate(TargetingPackage package)
    {
        currentPackage = package;
        gameObject.SetActive(true);
        CombatHandler.Events.Subscribe<CombatEvent.TargetsAquiredEvent>(e => Deactivate());
    }

    private void Deactivate()
    {
        CombatHandler.Events.Unsubscribe<CombatEvent.TargetsAquiredEvent>(e => Deactivate());
        gameObject.SetActive(false);
    }

    public void OnSelect(BaseEventData eventData)
    {
        currentPackage.Clicked = myCombatant;
        CombatHandler.Events.Publish(new CombatEvent.AbilityConfirmedEvent(currentPackage));
    }

    public void Initialize(Combatant c)
    {
        gameObject.SetActive(false);
        myCombatant = c;
    }
}
