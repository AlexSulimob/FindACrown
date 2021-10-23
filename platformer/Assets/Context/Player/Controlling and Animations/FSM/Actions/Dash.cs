using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;
using System;

namespace PlaytformerPlayersActions
{
    [HutongGames.PlayMaker.ActionCategory("Platformer Players Action")]
    [HutongGames.PlayMaker.Tooltip("Dash")]
    public class Dash : BaseAction
    {
        public FsmEvent jumpInterruption;
        public float interruptionAfter = 0.15f;

        public float dashPower = 1000f;
        public float dashDrag = 5f;
        public float dashTime = 0.25f;
        float startTime;
        float _initGravity;

        public override void OnEnter()
        {
            base.OnEnter();
            player.JumpInput += OnJumpInput;

            player.PlayerTimings.DashCd.Start();
            startTime = Time.time;

            _initGravity = player.Rb.gravityScale;

            player.Rb.velocity = Vector2.zero;
            player.Rb.gravityScale = 0f;
            player.HorzontalDrag = dashDrag;

            player.Rb.AddForce(Vector2.right * dashPower * player.FacingDirection);

        }
        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();

            if (Time.time >= startTime + dashTime)
            {
                Finish();
            }

        }

        public override void OnExit()
        {
            base.OnExit();
            player.JumpInput -= OnJumpInput;

            player.HorzontalDrag = player.InitHorizontalDrag;
            player.VerticalDrag = player.InitVerticalDrag;
            player.Rb.gravityScale = _initGravity;
        }

        private void OnJumpInput()
        {
            if (Time.time >= startTime + interruptionAfter)
            {
                Fsm.Event(jumpInterruption);
                Finish();
            }
        }
    }
}