using Unity.VisualScripting;
using UnityEngine;

public abstract class CombatStep
{
    public bool IsCompleted => tasksUntilComplete <= 0;
    public abstract CombatStep NextStep { get; }
    private int tasksUntilComplete = 0;

    public abstract void Begin();

    public void CompleteTask()
    {
        tasksUntilComplete--;
    }

    protected void AddTask()
    {
        tasksUntilComplete++;
    }
}
