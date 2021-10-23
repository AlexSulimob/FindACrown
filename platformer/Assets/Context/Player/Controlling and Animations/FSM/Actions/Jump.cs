using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaytformerPlayersActions
{
    [HutongGames.PlayMaker.ActionCategory("Platformer Players Action")]
    [HutongGames.PlayMaker.Tooltip("Adding force Up to perform jump and setting up some flags")]
    public class Jump : BaseAction
    {
        public float JumpForce = 800f;

        public override void OnEnter()
        {
            base.OnEnter();
            player.Rb.velocity = new Vector2(player.Rb.velocity.x, 0f);
            player.Rb.AddForce(Vector2.up * JumpForce);
            player.Mediator.IsJumping = true;
            Finish();
        }
    }
}

