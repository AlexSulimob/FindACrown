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

                OnewayPlatformJumpLogic();
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

        void OnewayPlatformJumpLogic()
        {
            if (player.Movement.y < -0.1f && player.CurrentOnewayPlatform != null)
            {
                Fsm.FsmComponent.SendEvent("InAir");
                player.CurrentOnewayPlatform.DisableEffector();
                /*
                if (player.CurrentOnewayPlatform != null)
                {
                    Fsm.FsmComponent.SendEvent("InAir");
                    player.CurrentOnewayPlatform.DisableEffector();
                }
                else
                {
                    Fsm.FsmComponent.SendEvent("Jump");
                }
                */
            }
            else
            {
                Fsm.FsmComponent.SendEvent("Jump");
            }
        }
    }

}
