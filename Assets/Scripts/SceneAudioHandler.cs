using UnityEngine;

public abstract class SceneAudioHandler : MonoBehaviour
{
    [SerializeField]
    protected AudioSource musicSource;
    [SerializeField]
    protected AudioSource sfxSource;

    private void Awake()
    {
        InitializeEventListeners();
    }

    protected abstract void InitializeEventListeners();
}
