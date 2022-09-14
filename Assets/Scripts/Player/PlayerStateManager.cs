using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerSpeed))]
[RequireComponent(typeof(PlayerRotation))]
[RequireComponent(typeof(PlayerAnimation))]
public class PlayerStateManager : MonoBehaviour{
    public PlayerBaseState State { set { state = value; } }
    private PlayerBaseState state;

    private PlayerStateFactory stateFactory;

    public InputManager InputManager { get { return inputManager; } }
    private InputManager inputManager;
    public PlayerRotation PlayerRotation { get { return playerRotation; } }
    private PlayerRotation playerRotation;
    public PlayerSpeed PlayerMovement { get { return playerMovement; } }
    private PlayerSpeed playerMovement;

    //TODO: Implement Player Animation System
    private PlayerAnimation playerAnimation;




    private void Start(){
        inputManager = InputManager.Instance;
        inputManager.upldateSettings();

        playerMovement = GetComponent<PlayerSpeed>();
        playerRotation = GetComponent<PlayerRotation>();
        playerAnimation = GetComponent<PlayerAnimation>();

        stateFactory = new PlayerStateFactory(this);
        state = stateFactory.Idle();
    }

    private void Update(){
        state.UpdateState();
    }
}
