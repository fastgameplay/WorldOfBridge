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
        if (ctx.InputManager.Hold == false){
            SwitchState(state.Idle());
        }
    }
    public override void ExitState()
    {
    }

}
