using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaytformerPlayersActions
{
    [HutongGames.PlayMaker.ActionCategory("Platformer Players Action")]
    [HutongGames.PlayMaker.Tooltip("Variable jump heigh")]
    public class VariableJumpHeight : BaseAction
    {
        public float heightMultiplier = 0.5f;

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();

            if (player.Mediator.IsJumping)
            {
                if (player.Mediator.IsJumpKeyUp)
                {
                    player.Rb.velocity = new Vector2(player.Rb.velocity.x, player.Rb.velocity.y * heightMultiplier);
                    player.Mediator.IsJumping = false;
                }
                else if (player.Rb.velocity.y <= 0f)
                {
                    player.Mediator.IsJumping = false;
                }
            }
        }
    }

}
