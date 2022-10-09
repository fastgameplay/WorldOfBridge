using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : PlayerBaseState
{
    public PlayerDeathState(PlayerStateManager _ctx, PlayerStateFactory _factory) : base(_ctx, _factory) {}
    public override void EnterState()
    {
        ctx.PlayerAnimation.Speed = 0f;
        ctx.PlayerAnimation.Sit();
        ctx.PlayerHight.TargetHight = 2.80f - 0.5f;//HARDCODED
        ctx.PlayerSpeed.TargetSpeedPercent = 0f;
    }
    public override void UpdateState()
    {
    }
    public override void ExitState()
    {
    }
}
