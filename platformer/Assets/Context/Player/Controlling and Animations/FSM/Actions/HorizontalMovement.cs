using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaytformerPlayersActions
{
    [HutongGames.PlayMaker.ActionCategory("Platformer Players Action")]
    [HutongGames.PlayMaker.Tooltip("Horizontal Movement")]
    public class HorizontalMovement : BaseAction
    {
        public float speed = 10f;
        public float horizontalDrag = 20f;
        float _initDrag;
        public override void OnEnter()
        {
            base.OnEnter();

            _initDrag = player.HorzontalDrag;
            player.HorzontalDrag = horizontalDrag;
        }
        public override void OnExit()
        {
            base.OnExit();
            player.HorzontalDrag = _initDrag;
        }
        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();

            player.Rb.AddForce((Vector2.right * player.Movement.x) * speed * player.HorzontalDrag);
        }
    }
}