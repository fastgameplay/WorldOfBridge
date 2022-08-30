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
        if(ctx.InputManager.IsStatic == false){
            ctx.RotationDelta = -ctx.InputManager.HorizontalNormilized;
        }
        if(ctx.InputManager.IsStatic == true){
            //can be optimized
            ctx.RotationDelta = 0;
        }

        if (ctx.InputManager.Hold == false){
            SwitchState(state.Idle());
        }
    }
    public override void ExitState(){
        ctx.RotationDelta = 0;
    }

}
