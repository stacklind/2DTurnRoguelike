using UnityEngine;
using UnityEngine.SceneManagement;

public class TownHandler : MonoBehaviour
{
    public static EventBroker Events { get; private set; }

    [SerializeField]
    private GameObject shop;

    public TownHandler()
    {
        InitializeEvents();
    }

    public void BeginAdventure()
    {
        SceneManager.LoadScene("CombatScene");
    }

    public void OpenShop()
    {
        shop.SetActive(true);
    }

    private void InitializeEvents()
    {
        Events = new EventBroker();
    }
}
