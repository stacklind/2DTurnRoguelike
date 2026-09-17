using UnityEngine;

public class CombatAudioHandler : SceneAudioHandler
{
    protected override void InitializeEventListeners()
    {
        CombatHandler.Events.Subscribe<CombatEvent.BeginCombatEvent>(StartMusic);
        CombatHandler.Events.Subscribe<CombatEvent.PerformMoveEvent>(PlayMoveSfx);
    }

    private void StartMusic(CombatEvent.BeginCombatEvent evt)
    {
        musicSource.Play();
        evt.Step.CompleteTask();
    }

    private void PlayMoveSfx(CombatEvent.PerformMoveEvent evt)
    {
        // TODO
        evt.Step.CompleteTask();
    }
}
