using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    class TimedEvent
    {
        public float TimeToExecute { get; set; }
        public Action Method { get; set; }
    }

    private List<TimedEvent> events;

    private void Awake()
    {
        events = new List<TimedEvent>();
    }

    public void Add(float inSeconds, Action method)
    {
        events.Add(new TimedEvent { TimeToExecute = inSeconds, Method = method });
    }

    void Update()
    {
        var index = 0;
        while (index < events.Count)
        {
            var time = events[index].TimeToExecute;
            if (time <= Time.time)
            {
                events[index].Method?.Invoke();
                events.RemoveAt(index);
                continue;
            }

            index++;
        }
    }
}