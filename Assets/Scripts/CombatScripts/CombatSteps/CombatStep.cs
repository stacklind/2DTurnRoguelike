using Unity.VisualScripting;
using UnityEngine;

public abstract class CombatStep
{
    public bool IsCompleted { get; protected set; }
    public abstract CombatStep NextStep { get; }
    private int tasksUntilComplete = 0;

    protected CombatStep()
    {
        IsCompleted = false;
        Debug.Log($"Created step ({this.GetType()})");
    }

    public abstract void Begin();

    public void CompleteTask()
    {
        tasksUntilComplete--;
        if (tasksUntilComplete == 0)
        {
            IsCompleted = true;
        }
    }

    protected void AddTask()
    {
        tasksUntilComplete++;
    }
}
