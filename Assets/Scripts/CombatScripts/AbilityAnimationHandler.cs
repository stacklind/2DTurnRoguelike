using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AbilityAnimationHandler : MonoBehaviour
{
    private Animator _animator;
    private PerformAbilityStep step;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        CombatHandler.Events.Subscribe<CombatEvent.PerformAbilityEvent>(PlayAnimation);
    }

    private void PlayAnimation(CombatEvent.PerformAbilityEvent evt)
    {
        step = evt.Step;
        _animator.Play("Placeholder");
    }

    public void AnimationComplete()
    {
        step.CompleteTask();
    }
}
