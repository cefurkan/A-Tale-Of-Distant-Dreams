    using System.Collections.Generic;
    using System;

public enum GameEvent
{
    onSequenceStarted,
    onNextSequence,
    onSequenceEnded,
    onInteractable,
    onInteractionComplete,
    onInteractionAreaExit,
    onBgIntroEnded
};  

public static class EventManager
{
    // Stores the delegates that get called when an event is fired
    private static Dictionary<GameEvent, Action> eventTable
                 = new Dictionary<GameEvent, Action>();

    // Adds a delegate to get called for a specific event
    public static void AddHandler(GameEvent evnt, Action action)
    {
        if (!eventTable.ContainsKey(evnt)) eventTable[evnt] = action;
        else eventTable[evnt] += action;
    }

    // Fires the event
    public static void Broadcast(GameEvent evnt)
    {
        if (eventTable[evnt] != null) eventTable[evnt]();
    }
    public static void RemoveHandler(GameEvent evnt, Action action)
    {
        if (eventTable[evnt] != null)
            eventTable[evnt] -= action;
        if (eventTable[evnt] == null)
            eventTable.Remove(evnt);
    }
}
