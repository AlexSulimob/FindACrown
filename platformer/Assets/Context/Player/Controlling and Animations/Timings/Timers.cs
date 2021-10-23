using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwnTimerImlementation
{
    public class Timers
    {
        public Timer CayouteTimeGroundOff { get; private set; }
        public Timer WallOffCayouteTime { get; private set; }
        public Timer AirOffCayouteTime { get; private set; }

        public Timer DashCd { get; private set; }

        public Timers()
        {
            CayouteTimeGroundOff = new Timer("cayouteTimeGroundOff", 0.1f);
            AirOffCayouteTime = new Timer("cayouteTimeAirOff", 0.1f);
            WallOffCayouteTime = new Timer("cayouteTimeWallOff", 0.1f);

            DashCd = new Timer("dashTime", 1f);
        }
    }

}
