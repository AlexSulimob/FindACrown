using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwnTimerImlementation
{
    public class Timer
    {
        public string name;
        public float duration;
        float startTime;

        public Timer(string name, float duration)
        {
            this.name = name;
            this.duration = duration;
        }
        public void Start()
        {
            startTime = Time.time;
        }
        public bool Check()
        {
            if (Time.time >= startTime + duration)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void EndTimer()
        {
            startTime = startTime - duration;
        }
    }
}

