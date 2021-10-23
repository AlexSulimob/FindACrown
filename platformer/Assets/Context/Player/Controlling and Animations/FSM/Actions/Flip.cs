using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaytformerPlayersActions
{
    [HutongGames.PlayMaker.ActionCategory("Platformer Players Action")]
    [HutongGames.PlayMaker.Tooltip("Flip sprite and facing direction of player")]
    public class Flip : BaseAction
    {
        public override void OnUpdate()
        {
            base.OnUpdate();

            FlipCondition();
            FlipSprite();
        }

        private void FlipCondition()
        {
            if (player.Rb.velocity.x < -0.1f && player.FacingDirection == 1)
            {
                player.Flip();
            }
            else if (player.Rb.velocity.x > 0.1f && player.FacingDirection == -1)
            {
                player.Flip();
            }
        }

        private void FlipSprite()
        {
            if (player.FacingDirection != 1)
            {
                player.Sprite.flipX = true;
            }
            else
            {
                player.Sprite.flipX = false;
            }
        }
    }

}
