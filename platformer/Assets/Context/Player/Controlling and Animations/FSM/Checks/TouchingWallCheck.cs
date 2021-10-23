using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;


namespace PlaytformerPlayersActions
{
    [HutongGames.PlayMaker.ActionCategory("Platformer Players Action")]
    [HutongGames.PlayMaker.Tooltip("Check if player is toucing a wall")]
    public class TouchingWallCheck : BaseAction
    {
        public FsmEvent TouchingWall;

        public FsmEvent Grounded;
        public FsmEvent InAir;

        public override void OnFixedUpdate()
        {
            base.OnEnter();

            if (player.CheckTouchingWall())
            {
                Fsm.Event(TouchingWall);
            }
            else
            {
                if (!player.CheckGround())
                {
                    Fsm.Event(InAir);
                }
            }

            if (player.CheckGround())
            {
                Fsm.Event(Grounded);
            }

        }
    }
}

