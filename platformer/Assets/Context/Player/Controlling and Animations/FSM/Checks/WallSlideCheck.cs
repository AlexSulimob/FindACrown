using HutongGames.PlayMaker;

namespace PlaytformerPlayersActions
{
    [HutongGames.PlayMaker.ActionCategory("Platformer Players Action")]
    [HutongGames.PlayMaker.Tooltip("Check if you are wallslidng ")]
    public class WallSlideCheck : BaseAction
    {
        [HutongGames.PlayMaker.Tooltip("Sends when player is going down")]
        public FsmEvent WallSlide;

        public override void OnEnter()
        {
            base.OnEnter();

            player.Mediator.CurrentWallDirections = -player.FacingDirection;
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();

            if (player.Rb.velocity.y < -0.1f)
            {
                Fsm.Event(WallSlide);
            }

        }


    }

}
