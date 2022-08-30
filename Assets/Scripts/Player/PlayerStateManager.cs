using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMovement))]
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

    private PlayerMovement playerMovement;

    //TODO: Implement Player Animation System
    private PlayerAnimation playerAnimation;


    public float Speed { set { playerMovement.TargetSpeed = value; } }


    private void Start(){
        inputManager = InputManager.Instance;
        inputManager.upldateSettings();

        playerMovement = GetComponent<PlayerMovement>();
        playerRotation = GetComponent<PlayerRotation>();
        playerAnimation = GetComponent<PlayerAnimation>();

        stateFactory = new PlayerStateFactory(this);
        state = stateFactory.Idle();
    }

    private void Update(){
        state.UpdateState();
    }
}
