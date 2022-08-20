using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAnimation))]
public class PlayerStateManager : MonoBehaviour{
    public PlayerBaseState State { set { state = value; } }
    private PlayerBaseState state;

    private PlayerStateFactory stateFactory;

    public InputManager InputManager { get { return InputManager; } }
    private InputManager inputManager;
    public PlayerMovement PlayerMovement { get { return playerMovement; } }
    private PlayerMovement playerMovement;
    public PlayerAnimation PlayerAnimation { get { return playerAnimation; } }
    private PlayerAnimation playerAnimation;


    private void Start(){
        inputManager = InputManager.Instance;

        playerMovement = GetComponent<PlayerMovement>();
        playerAnimation = GetComponent<PlayerAnimation>();
        
        stateFactory = new PlayerStateFactory(this);
        state = stateFactory.Idle();
    }

    private void Update(){
        state.UpdateState();
    }
}
