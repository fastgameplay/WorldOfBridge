using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(PlayerStateManager _ctx, PlayerStateFactory _factory) : base(_ctx, _factory) { }

    public override void EnterState()
    {
        ctx.Speed = 0.2f;
    }
    public override void UpdateState(){
        ctx.PlayerRotation.AddToTargetRotation( -ctx.InputManager.HorizontalNormilized);

        ctx.Speed = 0.175f - 0.065f * Mathf.Abs(ctx.InputManager.HorizontalNormilized);

        if (ctx.InputManager.Hold == false){
            SwitchState(state.Idle());
        }
    }
    public override void ExitState(){
    }

}
