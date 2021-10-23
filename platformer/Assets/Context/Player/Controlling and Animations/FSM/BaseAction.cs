using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PlaytformerPlayersActions
{
    [HutongGames.PlayMaker.ActionCategory("Platformer Players Action")]
    [HutongGames.PlayMaker.Tooltip("Base Action")]
    public class BaseAction : FsmStateAction
    {
        protected Player player { get; private set; }

        public override void OnEnter()
        {
            base.OnEnter();
            player = Owner.GetComponent<Player>();

        }
        public override void OnExit()
        {
            base.OnExit();
        }

        public override void OnPreprocess()
        {
            Fsm.HandleFixedUpdate = true;
        }

    }

}
