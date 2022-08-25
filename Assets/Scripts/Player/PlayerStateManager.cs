using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAnimation))]
public class PlayerStateManager : MonoBehaviour{
    public PlayerBaseState State { set { state = value; } }
    private PlayerBaseState state;

    private PlayerStateFactory stateFactory;

    public InputManager InputManager { get { return inputManager; } }
    private InputManager inputManager;

    private PlayerMovement playerMovement;
    private PlayerAnimation playerAnimation;

    
    public float Speed { set { playerMovement.TargetSpeed = value; } }
    
    private void Start(){
        inputManager = InputManager.Instance;
        inputManager.upldateSettings();

        playerMovement = GetComponent<PlayerMovement>();
        playerAnimation = GetComponent<PlayerAnimation>();
        
        stateFactory = new PlayerStateFactory(this);
        state = stateFactory.Idle();
    }

    private void Update(){
        state.UpdateState();
    }
}
