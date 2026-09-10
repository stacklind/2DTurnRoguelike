using UnityEngine;

public class Healthbar : MonoBehaviour
{
    [SerializeField]
    private Transform currentHealth;

    private float target;
    private float current;
    private float step;

    private void Start()
    {
        target = current = 1f;
        step = 0;
    }

    private void Update()
    {
        if(target != current)
        {
            step += 0.5f * Time.deltaTime;
            float temp = Mathf.Lerp(current, target, step);
            currentHealth.localScale = new Vector3(temp, 1f, 1f);

            if (step > 1.0f)
            {
                current = target;
                step = 0;
            }
        }
    }

    public void UpdateHealthbar(float ratio)
    {
        target = Mathf.Round(ratio * 100f) / 100f;
    }
}
