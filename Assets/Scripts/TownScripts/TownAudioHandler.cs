using UnityEngine;

public class TownAudioHandler : SceneAudioHandler
{
    protected override void InitializeEventListeners()
    {
        TownHandler.Events.Subscribe<TownEvent.CharacterSelectedEvent>(OnCharacterSelected);
        TownHandler.Events.Subscribe<TownEvent.CharacterConfirmedEvent>(OnCharacterConfirmed);
    }

    private void OnCharacterSelected(TownEvent.CharacterSelectedEvent evt)
    {
        PlayableCharacterAudio pca = (PlayableCharacterAudio)evt.Character.Audio;
        PlaySfx(pca.Selected);
    }

    private void OnCharacterConfirmed(TownEvent.CharacterConfirmedEvent evt)
    {
        PlayableCharacterAudio pca = (PlayableCharacterAudio)evt.Character.Audio;
        PlaySfx(pca.Confirmed);
    }

    private void PlaySfx(AudioClip clip)
    {
        sfxSource.Stop();
        sfxSource.PlayOneShot(clip);
    }
}
