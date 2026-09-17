using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MoveAnimationHandler : MonoBehaviour
{
    private Animator _animator;
    private PerformMoveStep step;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        CombatHandler.Events.Subscribe<CombatEvent.PerformMoveEvent>(PlayAnimation);
    }

    private void PlayAnimation(CombatEvent.PerformMoveEvent evt)
    {
        step = evt.Step;
        _animator.Play("Placeholder");
    }

    public void AnimationComplete()
    {
        step.CompleteTask();
    }
}
