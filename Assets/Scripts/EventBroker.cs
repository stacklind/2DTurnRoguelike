using System;
using System.Collections.Generic;

public class EventBroker
{
    private Dictionary<Type, Delegate> eventDictionary;

    public EventBroker()
    {
        eventDictionary = new Dictionary<Type, Delegate>();
    }

    public void Subscribe<T>(Action<T> listener)
    {
        if (eventDictionary.TryGetValue(typeof(T), out Delegate existingDelegate))
        {
            eventDictionary[typeof(T)] = (existingDelegate as Action<T>) + listener;
        }
        else
        {
            eventDictionary[typeof(T)] = listener;
        }
    }

    public void Unsubscribe<T>(Action<T> listener)
    {
        if (eventDictionary.TryGetValue(typeof(T), out Delegate existingDelegate))
        {
            eventDictionary[typeof(T)] = (existingDelegate as Action<T>) - listener;
        }
    }

    public void Publish<T>(T eventObject)
    {
        if (eventDictionary.TryGetValue(typeof(T), out Delegate existingDelegate))
        {
            (existingDelegate as Action<T>)?.Invoke(eventObject);
        }
    }

    public int Debug()
    {
        return eventDictionary.Count;
    }
}
