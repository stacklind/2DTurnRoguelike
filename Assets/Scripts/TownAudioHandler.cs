using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TownAudioHandler : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        InitializeEventListeners();
    }

    private void InitializeEventListeners()
    {
        TownHandler.Events.Subscribe<TownEvent.CharacterSelectedEvent>(OnCharacterSelected);
        TownHandler.Events.Subscribe<TownEvent.CharacterConfirmedEvent>(OnCharacterConfirmed);
    }

    private void OnCharacterSelected(TownEvent.CharacterSelectedEvent evt)
    {
        PlayableCharacterAudio pca = (PlayableCharacterAudio)evt.Character.Audio;
        Play(pca.Selected);
    }

    private void OnCharacterConfirmed(TownEvent.CharacterConfirmedEvent evt)
    {
        PlayableCharacterAudio pca = (PlayableCharacterAudio)evt.Character.Audio;
        Play(pca.Confirmed);
    }

    private void Play(AudioClip clip)
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(clip);
    }
}
