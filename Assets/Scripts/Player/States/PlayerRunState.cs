using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(PlayerStateManager _ctx, PlayerStateFactory _factory) : base(_ctx, _factory) { }

    public override void EnterState()
    {
        ctx.PlayerSpeed.TargetSpeedPercent = 1f;
        ctx.PlayerAnimation.Speed = 1f;
    }
    public override void UpdateState(){
        ctx.PlayerRotation.HorizontalInput = ctx.InputManager.HorizontalNormilized;

        ctx.PlayerSpeed.TargetSpeedPercent = (2 - Mathf.Abs(ctx.InputManager.HorizontalNormilized)) /2;

        if (ctx.InputManager.Hold == false){
            SwitchState(state.Idle());
        }
    }
    public override void ExitState(){
        ctx.PlayerRotation.HorizontalInput = 0;
    }

}
