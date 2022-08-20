using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState{
    protected PlayerStateManager ctx;
    protected PlayerStateFactory factory;
    public PlayerBaseState(PlayerStateManager _ctx, PlayerStateFactory _factory){
        ctx = _ctx;
        factory = _factory;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();

    protected void SwitchState(PlayerBaseState newState){
        ExitState();
        newState.EnterState();
        ctx.State = newState;
    }

}
