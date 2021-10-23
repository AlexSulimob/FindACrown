using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PlaytformerPlayersActions
{
    [HutongGames.PlayMaker.ActionCategory("Platformer Players Action")]
    [HutongGames.PlayMaker.Tooltip("Set Animation and turn off when quit")]
    public class SetStateAnimation : FsmStateAction
    {
        public string animName;
        public bool EveryFrame = true;
        
        protected Player player { get; private set; }

        public override void OnEnter()
        {
            base.OnEnter();
            player = Owner.GetComponent<Player>();
            //player.Anim.SetFloat("yVelocity", player.Rb.velocity.y);

            if (animName != string.Empty)
                player.Anim.SetBool(animName, true);

            if (!EveryFrame)
                Finish();
        }
        public override void OnExit()
        {
            base.OnExit();

            if (animName != string.Empty)
                player.Anim.SetBool(animName, false);
        }
        public override void OnUpdate()
        {
            base.OnUpdate();

            player.Anim.SetFloat("yVelocity", player.Rb.velocity.y);
            //Debug.Log("set y Velocity to " + player.Rb.velocity.y);
        }

    }
}