using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaytformerPlayersActions
{
    [HutongGames.PlayMaker.ActionCategory("Platformer Players Action")]
    [HutongGames.PlayMaker.Tooltip("Wall jump ")]
    public class WallJump : BaseAction
    {
        //private int wallJumpDirection;       

        public Vector2 wallJumpAngle;
        public float horizontalJumpForce = 800f;
        public float verticalJumpForce = 1200f;
        public float drag = 0f;
        public float duration = 0.15f;

        float _initHDrag;
        float _initVDrag;
        float _initTime;

        public override void OnEnter()
        {
            base.OnEnter();
            _initTime = Time.time;

            wallJumpAngle.Normalize();

            //wallJumpDirection = -player.FacingDirection;
            _initHDrag = player.HorzontalDrag;
            _initVDrag = player.VerticalDrag;

            player.HorzontalDrag = drag;
            player.VerticalDrag = drag;

            player.Rb.velocity = Vector2.zero;          
            player.Rb.AddForce(new Vector2(wallJumpAngle.x * horizontalJumpForce * player.Mediator.CurrentWallDirections, wallJumpAngle.y * verticalJumpForce));




        }
        public override void OnExit()
        {
            base.OnExit();

            player.HorzontalDrag = _initHDrag;
            player.VerticalDrag = _initVDrag;

        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (Time.time > _initTime + duration)
            {
                DashFinish();
            }

            //Debug.Log(player.Anim.GetFloat("yVelocity"));
        }

        private void DashFinish()
        {
            if(player.Movement.x != player.Mediator.CurrentWallDirections && player.Movement.x!=0)
            {
                Fsm.FsmComponent.SendEvent("ReverseWallJump");
            }
            else
            {
                player.Mediator.IsJumping = true; // flag for variable jump height after wall jump
                Fsm.FsmComponent.SendEvent("InAir");
            }

        }
    }

}
