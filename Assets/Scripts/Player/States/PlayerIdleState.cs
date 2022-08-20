using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateManager _ctx, PlayerStateFactory _factory) : base(_ctx, _factory) {}

    public override void EnterState()
    {
    }
    public override void UpdateState(){
        if (ctx.InputManager.Tap){
            SwitchState(factory.Run());
        }
    }
    public override void ExitState()
    {
    }
}
