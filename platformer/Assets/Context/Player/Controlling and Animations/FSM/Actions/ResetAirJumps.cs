

namespace PlaytformerPlayersActions
{
    [HutongGames.PlayMaker.ActionCategory("Platformer Players Action")]
    [HutongGames.PlayMaker.Tooltip("Reset allowed amount of air jumps")]
    public class ResetAirJumps : BaseAction
    {
        public override void OnEnter()
        {
            base.OnEnter();
            player.Mediator.ResetAirJump();
            Finish();
        }
    }

}
