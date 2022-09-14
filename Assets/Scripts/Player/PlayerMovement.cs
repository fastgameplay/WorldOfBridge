    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField] private float AccelerationRate;
    [SerializeField] private float MaxSpeed;
    
    [SerializeField] private GameObject PlayerModelHolder;
    

    public float TargetSpeedPercent { 
        set {
            if (value < 0) value = 0;
            targetSpeed = MaxSpeed * value; 

        } 
    }
    private float targetSpeed = 0;
    private float currentSpeed;


    public float TargetHight
    {
        set { 
            targetHight = value;
            isHightChange = true;
        }

    }
    private float targetHight;
    private float hight
    {
        get
        {
            return PlayerModelHolder.transform.localPosition.y;
        }
        set
        {
            PlayerModelHolder.transform.localPosition = new Vector3(0.0f, value, 0.0f);
        }
    }
    private bool isHightChange = false;

    private void Update(){
        CalculateSpeed();
        CalculateHight();
        Movement();
    }

    private void Movement(){
        if (currentSpeed != 0)
        {
            transform.Translate(Vector3.forward * currentSpeed);
        }
    }
    private void CalculateSpeed(){
        if (currentSpeed == targetSpeed) return;
        if (currentSpeed > targetSpeed){
            currentSpeed = targetSpeed;
        }
        
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, AccelerationRate);     
    }
    private void CalculateHight(){
        if (isHightChange == false) return;

        if (hight > targetHight){
            currentSpeed = targetSpeed;
            isHightChange = false;
        }

        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, AccelerationRate);

    }
}
