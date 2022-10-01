using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBridgeState : PlayerBaseState
{
    public PlayerBridgeState(PlayerStateManager _ctx, PlayerStateFactory _factory) : base(_ctx, _factory) {}

    public override void EnterState(){
        ctx.PlayerSpeed.TargetSpeedPercent = 0.8f;
        ctx.PlayerRotation.HorizontalInput = 0;
    }
    public override void UpdateState()
    {
    }
    public override void ExitState()
    {
    }
}
