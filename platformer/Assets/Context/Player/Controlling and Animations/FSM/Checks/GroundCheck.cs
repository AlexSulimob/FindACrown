using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PlaytformerPlayersActions
{
    [HutongGames.PlayMaker.ActionCategory("Platformer Players Action")]
    [HutongGames.PlayMaker.Tooltip("Checks ground and send event")]
    public class GroundCheck : BaseAction
    {
        public FsmEvent Grounded;
        public FsmEvent NotGrounded;

        public override void OnFixedUpdate()
        {
            base.OnEnter();

            if (player.CheckGround())
            {
                Fsm.Event(Grounded);
            }
            else
            {
                Fsm.Event(NotGrounded);
            }
            //Finish();
        }
    }



}
