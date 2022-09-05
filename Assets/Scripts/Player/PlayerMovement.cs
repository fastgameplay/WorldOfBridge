    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float AccelerationRate;
    [SerializeField] private float MaxSpeed;

    public float TargetSpeedPercent { 
        set {
            if (value < 0) value = 0;
            targetSpeed = MaxSpeed * value; 
        } 
    }
    private float targetSpeed = 0;
    private float currentSpeed;
    
    
    private void Update(){
        CalculateSpeed();
        if(currentSpeed != 0){
            transform.Translate(Vector3.forward * currentSpeed);
        }
    }

    private void CalculateSpeed(){
        if (currentSpeed == targetSpeed) return;
        if (currentSpeed > targetSpeed) currentSpeed = targetSpeed;
        
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, AccelerationRate);     
    }
}
