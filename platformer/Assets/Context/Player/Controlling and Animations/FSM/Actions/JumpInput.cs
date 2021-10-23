using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PlaytformerPlayersActions
{
    [HutongGames.PlayMaker.ActionCategory("Platformer Players Action")]
    [HutongGames.PlayMaker.Tooltip("Handle Jump Input")]
    public class JumpInput : BaseAction
    {
        [HutongGames.PlayMaker.Tooltip("Send when jump button is pressed")]
        public FsmEvent Jump;

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
            Fsm.Event(Jump);
        }
    }
}

