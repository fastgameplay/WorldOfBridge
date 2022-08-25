using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState{
    protected PlayerStateManager ctx;
    protected PlayerStateFactory state;
    public PlayerBaseState(PlayerStateManager _ctx, PlayerStateFactory _factory){
        ctx = _ctx;
        state = _factory;
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
