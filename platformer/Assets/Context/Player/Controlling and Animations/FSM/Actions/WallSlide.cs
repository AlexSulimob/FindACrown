using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

namespace PlaytformerPlayersActions
{
    [HutongGames.PlayMaker.ActionCategory("Platformer Players Action")]
    [HutongGames.PlayMaker.Tooltip("Wall slide, just set constant velocity y")]
    public class WallSlide : BaseAction
    {
        public float slidingSpeed = -5f;


        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();

            player.Rb.velocity = new Vector2(player.Rb.velocity.x, slidingSpeed);
        }


    }

}
