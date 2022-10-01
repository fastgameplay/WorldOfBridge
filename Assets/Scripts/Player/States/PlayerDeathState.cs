using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : PlayerBaseState
{
    public PlayerDeathState(PlayerStateManager _ctx, PlayerStateFactory _factory) : base(_ctx, _factory) {}
    public override void EnterState()
    {
        ctx.PlayerSpeed.TargetSpeedPercent = 0f;
        ctx.PlayerHight.StopMotion();
    }
    public override void UpdateState()
    {
    }
    public override void ExitState()
    {
    }
}
