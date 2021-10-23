using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace PlaytformerPlayersActions
{
    [HutongGames.PlayMaker.ActionCategory("Platformer Players Action")]
    [HutongGames.PlayMaker.Tooltip("Setup logic of falling")]
    public class FallingModification : BaseAction
    {
        public float maxFallingSpeed = -40f;

        public bool changeFallingGravity = true;

        public float velocityYWhenGravityChange = 1f;
        public float newGravity = 3f;
        public float timeToChangeGravity = 0.25f;

        float _initGravity;
        bool _isChangingGravity;

        public override void Awake()
        {
            base.Awake();
            DOTween.Init();
 
        }
        public override void OnEnter()
        {
            base.OnEnter();
            
            _initGravity = player.BaseGravity;
        }
        public override void OnExit()
        {
            base.OnExit();
            DOTween.Kill("GravityChange");
            player.Rb.gravityScale = player.BaseGravity;
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
            
            if(changeFallingGravity)
            {
                ChangeGravity();
            }
            //Debug.Log(player.Rb.gravityScale);
            MaxFallingSpeedRestriction();

        }
        void ChangeGravity()
        {
            if(player.Rb.velocity.y <= velocityYWhenGravityChange)
            {
                if (!DOTween.IsTweening("GraviyChange"))
                {
                    DOTween.To(() => player.Rb.gravityScale, x => player.Rb.gravityScale = x, newGravity, timeToChangeGravity).SetId("GravityChange");
                }
            }
            else
            {
                if (DOTween.IsTweening("GraviyChange"))
                {
                    DOTween.Kill("GraviyChange");
                }

                player.Rb.gravityScale = _initGravity;
            }
        }
        void MaxFallingSpeedRestriction()
        {
            if (player.Rb.velocity.y <= maxFallingSpeed)
            {
                player.Rb.velocity = new Vector2(player.Rb.velocity.x, maxFallingSpeed);
            }
        }

    }

}
