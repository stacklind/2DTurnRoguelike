using UnityEngine;

public class CombatAudioHandler : SceneAudioHandler
{
    protected override void InitializeEventListeners()
    {
        CombatHandler.Events.Subscribe<CombatEvent.BeginCombatEvent>(StartMusic);
        CombatHandler.Events.Subscribe<CombatEvent.PerformAbilityEvent>(PlayAbilitySfx);
    }

    private void StartMusic(CombatEvent.BeginCombatEvent evt)
    {
        musicSource.Play();
    }

    private void PlayAbilitySfx(CombatEvent.PerformAbilityEvent evt)
    {
        // TODO
        evt.Step.CompleteTask();
    }
}
