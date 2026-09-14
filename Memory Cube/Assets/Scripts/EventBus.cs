using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine.Events;

public enum EventBusTypes
{
    REPLAY
}

public class EventBus
{
    private static readonly IDictionary<EventBusTypes, UnityEvent> Events = new Dictionary<EventBusTypes, UnityEvent>();

    public static void Subscribe (EventBusTypes eventType, UnityAction listener)
    {

        UnityEvent thisEvent;

        if (Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Events.Add(eventType, thisEvent);
        }
    }

    public static void Unsubscribe (EventBusTypes type, UnityAction listener)
    {
        UnityEvent thisEvent;

        if (Events.TryGetValue(type, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void Publish(EventBusTypes type)
    {
        UnityEvent thisEvent;

        if (Events.TryGetValue(type, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}
