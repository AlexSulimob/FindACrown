using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlaytformerPlayersActions
{
    [HutongGames.PlayMaker.ActionCategory("Platformer Players Action")]
    [HutongGames.PlayMaker.Tooltip("Controlling jump events when jump input performed ")]
    public class InAirJumpInputsController : BaseAction
    {

        public override void OnEnter()
        {
            base.OnEnter();

            player.JumpInput += OnJumpInput;
        }

        public override void OnExit()
        {
            base.OnExit();

            player.JumpInput -= OnJumpInput;
        }


        void OnJumpInput()
        {
            if (!player.PlayerTimings.CayouteTimeGroundOff.Check()) //jump in cayoute time when run off platform and press jump
            {
                player.PlayerTimings.CayouteTimeGroundOff.EndTimer();
                Fsm.FsmComponent.SendEvent("Jump");
            }
            else if (!player.PlayerTimings.WallOffCayouteTime.Check()) //wall jump in cayoute time when climb off platform and press jump
            {
                player.PlayerTimings.WallOffCayouteTime.EndTimer();
                Fsm.FsmComponent.SendEvent("WallJump");
            }
            else if (player.Mediator.CanAirJump()) //air jump
            {
                Fsm.FsmComponent.SendEvent("AirJump");
                player.Mediator.PerformAirJump();
            }
            else
            {
                player.PlayerTimings.AirOffCayouteTime.Start(); //started cayoute time for jump on ground
            }

        }

    }

}
