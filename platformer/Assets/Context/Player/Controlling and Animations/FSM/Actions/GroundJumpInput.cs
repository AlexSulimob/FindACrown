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
            if(player.Movement.y < -0.1f)
            {
                OnewayPlatformManager opm = player.CheckOnewayPlatformManager();
                if (opm != null)
                {
                    Fsm.Event(InAir);
                    opm.DisableEffector();
                }
                else
                {
                    Fsm.Event(Jump);
                }                      
            }
            else
            {
                Fsm.Event(Jump);
            }

        }
    }
}