using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PlaytformerPlayersActions
{
    public class GroundJumpInput : BaseAction
    {
        [HutongGames.PlayMaker.Tooltip("Send when jump button is pressed")]
        public FsmEvent Jump;
        [HutongGames.PlayMaker.Tooltip("Send when jump off one way platform")]
        public FsmEvent InAir;

        public override void OnEnter()
        {
            base.OnEnter();
            player.JumpInput += SendJump;

        }
        public override void OnExit()
        {
            base.OnExit();
            player.JumpInput -= SendJump;
        }


        public void SendJump()
        {
            OnewayPlatformJumpLogic();
        }

        void OnewayPlatformJumpLogic()
        {
            if (player.Movement.y < -0.1f && player.CurrentOnewayPlatform != null)
            {
                Fsm.Event(InAir);
                player.CurrentOnewayPlatform.DisableEffector();
                /*
                if (player.CurrentOnewayPlatform != null)
                {
                    Fsm.Event(InAir);
                    player.CurrentOnewayPlatform.DisableEffector();
                }
                else
                {
                    Fsm.Event(Jump);
                }
                */
            }
            else
            {
                Fsm.Event(Jump);
            }
        }
    }
}