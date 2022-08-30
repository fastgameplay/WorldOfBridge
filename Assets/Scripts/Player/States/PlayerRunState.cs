using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(PlayerStateManager _ctx, PlayerStateFactory _factory) : base(_ctx, _factory) { }

    public override void EnterState()
    {
        ctx.Speed = 0.4f;
    }
    public override void UpdateState(){
        ctx.TargetRotation += -ctx.InputManager.HorizontalNormilized;

        ctx.Speed = 0.3f - Mathf.Abs(ctx.InputManager.HorizontalNormilized)/ 10;

        if (ctx.InputManager.Hold == false){
            SwitchState(state.Idle());
        }
    }
    public override void ExitState(){
    }

}
