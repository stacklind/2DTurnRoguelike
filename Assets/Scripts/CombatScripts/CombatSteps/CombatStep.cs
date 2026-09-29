using Unity.VisualScripting;
using UnityEngine;

public abstract class CombatStep
{
    private int tasksUntilComplete = 0;
    public bool IsCompleted => tasksUntilComplete <= 0;
    public abstract CombatStep NextStep { get; }

    public int Test => tasksUntilComplete;

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
