using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image currentHealth;
    private void Awake()
    {
        currentHealth = transform.Find("Max/Current").GetComponent<Image>();
    }

    public float Ratio 
    {
        set
        {
            currentHealth.fillAmount = value;
        }
    }
}
