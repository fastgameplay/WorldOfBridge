using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateFactory
{
    readonly PlayerStateManager context;
    readonly Dictionary<PlayerStateEnum, PlayerBaseState> States;

    public PlayerStateFactory(PlayerStateManager _context)
    {
        context = _context;
        //instantiate states
        States = new Dictionary<PlayerStateEnum, PlayerBaseState>() {
        { PlayerStateEnum.IDLE , new PlayerIdleState(context,this)},
        { PlayerStateEnum.RUN , new PlayerRunState(context,this)},
        { PlayerStateEnum.BRIDGE , new PlayerBridgeState(context,this)},
        { PlayerStateEnum.DEATH , new PlayerDeathState(context,this)},
        { PlayerStateEnum.FINISH , new PlayerFinishState(context,this)}
        };
    }
    public PlayerBaseState State(PlayerStateEnum stateEnum){
        return States[stateEnum];
    }
    public PlayerBaseState Idle()
    {
        return States[PlayerStateEnum.IDLE];
    }
    public PlayerBaseState Run()
    {
        return States[PlayerStateEnum.RUN];
    }
    public PlayerBaseState Bridge()
    {
        return States[PlayerStateEnum.BRIDGE];

    }
    public PlayerBaseState Death()
    {
        return States[PlayerStateEnum.DEATH];

    }
    public PlayerBaseState Finish()
    {
        return States[PlayerStateEnum.FINISH];

    }
}