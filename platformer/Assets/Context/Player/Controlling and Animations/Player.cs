using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using System;
using DG.Tweening;
using OwnTimerImlementation;
using UnityEngine.SceneManagement;
using Newtonsoft.Json; 

namespace PlaytformerPlayersActions
{

    public class Player : MonoBehaviour
    {
        #region Components

        public Rigidbody2D Rb { get; private set; }
        public PlayMakerFSM PlyerFsm { get; private set; }
        public Animator Anim { get; private set; }
        public SpriteRenderer Sprite { get; private set; }

        #endregion

        public Vector2 Movement { get; private set; }
        public int FacingDirection { get; set; }

        public float HorzontalDrag { get; set; }
        public float VerticalDrag { get; set; }

        public float InitHorizontalDrag = 40f;
        public float InitVerticalDrag = 0f;

        public float BaseGravity { get; set; }

        #region TransformsChecks and paramets of these

        public Transform groundCheck;
        public float groundCheckRadius;

        public Transform wallCheck;
        public float wallCheckDistance = 0.5f;

        public LayerMask CollisionLayer;
        #endregion

        #region global things
        GameSaves gameSaves;

        public PlayerMediator Mediator { get; private set; }
        public Timers PlayerTimings { get; private set; }
        public PlayerAllowedAbilities AllowedAbilities { get; private set; }
        public Vector2 CurrentRespawnPoint { get; set; }
        public OnewayPlatformManager CurrentOnewayPlatform { get; set; }
        #endregion

        public event Action JumpInput;

        #region Unity CallBacks

        public void Awake()
        {
            Rb = GetComponent<Rigidbody2D>();
            PlyerFsm = GetComponent<PlayMakerFSM>();
            Mediator = new PlayerMediator();
            PlayerTimings = new Timers();
            Anim = GetComponent<Animator>();
            Sprite = GetComponent<SpriteRenderer>();
            AllowedAbilities = new PlayerAllowedAbilities();

            BaseGravity = Rb.gravityScale;
            HorzontalDrag = InitHorizontalDrag;
            VerticalDrag = InitVerticalDrag;

            AllowedAbilities.CanAirJump = JasonWeimannSingleton.Singleton<GameSaves>.Instance.data.CanAirJump;
            AllowedAbilities.CanDash = JasonWeimannSingleton.Singleton<GameSaves>.Instance.data.CanDash;
            AllowedAbilities.CanWallSlide = JasonWeimannSingleton.Singleton<GameSaves>.Instance.data.CanWallSlide;

            Rb.velocity = Vector2.zero;
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += SceneLoaded;

        }
        private void OnDisable()
        {
            SceneManager.sceneLoaded -= SceneLoaded;
        }

        private void SceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == SceneManager.GetActiveScene().name)
            {
                //Rb.MovePosition(JasonWeimannSingleton.Singleton<GameSaves>.Instance.data.currentCheckPoint);
                Rb.velocity = Vector2.zero;
                Rb.position = JasonWeimannSingleton.Singleton<GameSaves>.Instance.data.currentCheckPoint;
            }
        }
        public void Death()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


        private void FixedUpdate()
        {     
            Drag();
        }
        private void Update()
        {
            AllowedAbilities.CanAirJump = JasonWeimannSingleton.Singleton<GameSaves>.Instance.data.CanAirJump;
            AllowedAbilities.CanDash = JasonWeimannSingleton.Singleton<GameSaves>.Instance.data.CanDash;
            AllowedAbilities.CanWallSlide = JasonWeimannSingleton.Singleton<GameSaves>.Instance.data.CanWallSlide;
        }
        #endregion

        #region Input Calls
        void OnRestartLevel()
        {
            Death();
        }
        void OnMovement(InputValue value)
        {
            var RawMovementInput = value.Get<Vector2>();

            var NormInputX = Mathf.RoundToInt(RawMovementInput.x);
            var NormInputY = Mathf.RoundToInt(RawMovementInput.y);

            FacingDirection = NormInputX != 0 ? NormInputX : FacingDirection;

            Movement = new Vector2(NormInputX, NormInputY);
            //Debug.Log(FacingDirection);
        }
        void OnJump(InputValue value)
        {
            //Debug.Log(value.isPressed);
        
            if (value.isPressed)
            {
                JumpInput?.Invoke();

                //PlyerFsm.SendEvent("Jump");
                Mediator.IsJumpKeyUp = false; 
            }
            else 
            {
                Mediator.IsJumpKeyUp = true;
            }
        

        }
        void OnDash()
        {
            if (PlayerTimings.DashCd.Check() && AllowedAbilities.CanDash)
                PlyerFsm.SendEvent("Dash");
        }
        #endregion

        #region Sets Funcs

        public void Flip()
        {
            FacingDirection *= -1;
        }

        void Drag()
        {
            Rb.velocity = new Vector2(Rb.velocity.x * Mathf.Clamp01(1f - HorzontalDrag * Time.deltaTime), Rb.velocity.y);
            Rb.velocity = new Vector2(Rb.velocity.x, Rb.velocity.y * Mathf.Clamp01(1f - VerticalDrag * Time.deltaTime));
        }

        #endregion

        #region Check Funcs

        public bool CheckGround()
        {
            return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1f, 0.05f), CapsuleDirection2D.Horizontal, 0f, CollisionLayer);
        }

        public bool CheckTouchingWall()
        {
            return Physics2D.Raycast(wallCheck.position, Vector2.right * FacingDirection, wallCheckDistance, CollisionLayer);
        }
        #endregion
        /*
        public OnewayPlatformManager CheckOnewayPlatformManager()
        {
            var col = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1f, 0.05f), CapsuleDirection2D.Horizontal, 0f, CollisionLayer);
            return col.GetComponent<OnewayPlatformManager>();

        }
        */

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.z));
        }
    }
    //test change
}