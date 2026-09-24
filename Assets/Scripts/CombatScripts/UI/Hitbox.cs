using UnityEngine;
using UnityEngine.EventSystems;

public class Hitbox : MonoBehaviour, ISelectHandler
{
    private Combatant myCombatant;
    private TargetingPackage currentPackage;

    public void Activate(TargetingPackage package)
    {
        Debug.Log("Hitbox > Activate");

        currentPackage = package;
        gameObject.SetActive(true);
        CombatHandler.Events.Subscribe<CombatEvent.TargetsAquiredEvent>(e => Deactivate());
    }

    private void Deactivate()
    {
        Debug.Log("Hitbox > Deactivate");

        CombatHandler.Events.Unsubscribe<CombatEvent.TargetsAquiredEvent>(e => Deactivate());
        gameObject.SetActive(false);
    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log($"Hitbox > OnSelect ({myCombatant.gameObject.name})");

        currentPackage.Clicked = myCombatant;
        CombatHandler.Events.Publish(new CombatEvent.AbilityConfirmedEvent(currentPackage));
    }

    public void Initialize(Combatant c)
    {
        Debug.Log("Hitbox > Initialize");

        gameObject.SetActive(false);
        myCombatant = c;
    }
}
