using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaytformerPlayersActions
{
    [HutongGames.PlayMaker.ActionCategory("Platformer Players Action")]
    [HutongGames.PlayMaker.Tooltip("Execute Jump on Air off")]
    public class GroundCayouteTime : BaseAction
    {
        public override void OnEnter()
        {
            base.OnEnter();

            if (!player.PlayerTimings.AirOffCayouteTime.Check())
            {
                player.PlayerTimings.AirOffCayouteTime.EndTimer();
                Fsm.FsmComponent.SendEvent("Jump");
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            if (player.Mediator.IsJumpKeyUp && !player.CheckGround())
            {
                player.PlayerTimings.CayouteTimeGroundOff.Start();
            }
        }
    }

}
