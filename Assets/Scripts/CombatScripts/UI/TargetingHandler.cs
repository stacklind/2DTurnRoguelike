using UnityEngine;

public class TargetingHandler : MonoBehaviour
{
    private bool isTargetingActive;

    private void Start()
    {
        isTargetingActive = false;
        InitializeEvents();
    }

    private void Update()
    {
        if(isTargetingActive)
        {
            // Listen for right click (cancel targeting)
        }
    }

    private void InitializeEvents()
    {
        CombatHandler.Events.Subscribe<CombatEvent.AquireTargetsEvent>(OnAquireTarget);
    }

    private void OnAquireTarget(CombatEvent.AquireTargetsEvent evt)
    {
        if (!evt.Package.User.IsPlayer)
        {
            evt.Package.Clicked = evt.Package.PossibleTargets[Random.Range(0, evt.Package.PossibleTargets.Length)];
            CombatHandler.Events.Publish(new CombatEvent.AbilityConfirmedEvent(evt.Package));
        }
        else
        {
            isTargetingActive = true;

            foreach (Combatant target in evt.Package.PossibleTargets)
            {
                target.UI.HitBox.Activate(evt.Package);
            }
        }
    }
}
