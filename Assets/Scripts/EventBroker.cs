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
        Subscribe(typeof(T), listener);
    }

    public void Subscribe(Type eventType, Delegate listener)
    {
        if (eventDictionary.TryGetValue(eventType, out Delegate existingDelegate))
        {
            eventDictionary[eventType] = Delegate.Combine(existingDelegate, listener);
        }
        else
        {
            eventDictionary[eventType] = listener;
        }
    }

    public void Unsubscribe<T>(Action<T> listener)
    {
        Unsubscribe(typeof(T), listener);
    }

    public void Unsubscribe(Type eventType, Delegate listener)
    {
        if (eventDictionary.TryGetValue(eventType, out Delegate existingDelegate))
        {
            eventDictionary[eventType] = Delegate.Remove(existingDelegate, listener);
        }
    }

    public void Publish<T>(T eventObject)
    {
        if (eventDictionary.TryGetValue(typeof(T), out Delegate existingDelegate))
        {
            (existingDelegate as Action<T>)?.Invoke(eventObject);
        }
    }

    public int Debug(Type type)
    {
        return eventDictionary[type].GetInvocationList().Length;
    }
}
