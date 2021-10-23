using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaytformerPlayersActions
{
    public class InAirCayouteTime : BaseAction
    {
        public bool forShort;

        public override void OnExit()
        {
            base.OnExit();

            if (player.Mediator.IsJumpKeyUp && !player.CheckGround())
            {
                player.PlayerTimings.WallOffCayouteTime.Start();
            }

        }

        public override void OnEnter()
        {
            base.OnEnter();

            if (!player.PlayerTimings.AirOffCayouteTime.Check() && forShort)
            {
                player.PlayerTimings.AirOffCayouteTime.EndTimer();
                Fsm.FsmComponent.SendEvent("Jump");
            }
        }
    }

}
