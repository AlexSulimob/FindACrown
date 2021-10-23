using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PlaytformerPlayersActions
{
    [HutongGames.PlayMaker.ActionCategory("Platformer Players Action")]
    [HutongGames.PlayMaker.Tooltip("Inverts Horizontal Velocity")]
    public class ChangeHorizontalFacingVelocity : BaseAction
    {
        //private int wallJumpDirection;       
        public FsmEvent EventOnEnd;

        public override void OnEnter()
        {
            base.OnEnter();
            
            player.Rb.velocity = new Vector2(-player.Rb.velocity.x, player.Rb.velocity.y);

            Fsm.Event(EventOnEnd);
            Finish();

        }

    }
}

