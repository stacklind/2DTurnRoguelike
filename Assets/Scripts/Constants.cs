using UnityEngine;

public class Constants : MonoBehaviour
{
    public static Constants Instance { get; private set; }

    public PlayableCharacterBase[] PlayableBases;
    public MonsterBase[] MonsterBases;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    [ContextMenu("Functions/Reset")]
    public void ResetInEditor()
    {
        Instance = null;
    }
}
