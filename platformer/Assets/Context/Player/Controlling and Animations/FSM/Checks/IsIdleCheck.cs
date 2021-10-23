using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PlaytformerPlayersActions
{
    [HutongGames.PlayMaker.ActionCategory("Platformer Players Action")]
    [HutongGames.PlayMaker.Tooltip("Check if player is idle")]
    public class IsIdleCheck : BaseAction
    {
        public FsmEvent Idle;
        public FsmEvent Movement;

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (player.Movement.x != 0)
            {
                Fsm.Event(Movement);
            }
            else
            {
                Fsm.Event(Idle);
            }

        }
    }

}
