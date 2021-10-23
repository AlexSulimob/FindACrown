using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlaytformerPlayersActions;

[HutongGames.PlayMaker.ActionCategory("Platformer Players Action")]
[HutongGames.PlayMaker.Tooltip("Debug")]
public class DebugAction : BaseAction
{
    public override void OnEnter()
    {
        base.OnEnter();

        Debug.Log(player.Rb.velocity.y);
        Finish();
    }
}