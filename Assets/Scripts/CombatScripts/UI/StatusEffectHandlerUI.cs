using System.Collections.Generic;
using UnityEngine;

public class StatusEffectHandlerUI : MonoBehaviour
{
    [SerializeField]
    private StatusEffectInstanceUI[] statusEffectInstances;

    private Queue<StatusEffectInstanceUI> available;
    private Dictionary<string, StatusEffectInstanceUI> inUse;

    private void Awake()
    {
        available = new Queue<StatusEffectInstanceUI>(statusEffectInstances);
        inUse = new Dictionary<string, StatusEffectInstanceUI>();
        InitializeImages();
    }

    public void ApplyStatusEffect(StatusEffectInstance se)
    {
        if (available.Count == 0)
        {
            throw new System.IndexOutOfRangeException("Too few slots");
        }

        StatusEffectInstanceUI tmp = available.Dequeue();
        tmp.Image.sprite = se.Icon;
        tmp.StacksText.text = $"{se.Stacks}";
        inUse.Add(se.Name, tmp);
        tmp.gameObject.SetActive(true);
    }

    public void RemoveStatusEffect(StatusEffectInstance se)
    {
        StatusEffectInstanceUI tmp = inUse[se.Name];
        tmp.gameObject.SetActive(false);

        inUse.Remove(se.Name);
        available.Enqueue(tmp);
    }

    public void UpdateStatusEffect(StatusEffectInstance se)
    {
        inUse[se.Name].StacksText.text = $"{se.Stacks}";
    }

    private void InitializeImages()
    {
        foreach (StatusEffectInstanceUI sei in statusEffectInstances)
        {
            sei.gameObject.SetActive(false);
        }
    }
}
